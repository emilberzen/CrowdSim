using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock3D : MonoBehaviour
{

    public FlockAgent3D agentPrefab;
    public static List<FlockAgent3D> agents3D = new List<FlockAgent3D>();
    public FlockBehaviour3D behaviour;

    [Range(10, 1000)]
    public int startingCount = 250;
    const float AgentDenstity = 0.1f;

    [Range(0f, 100)]
    public float driveFactor = 10f;

    [Range(0f, 100)]
    public float maxSpeed = 5;

    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;


    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;


    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }



    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;


        for (int i = 0; i < startingCount; i++)
        {



            FlockAgent3D NewAgent = Instantiate(
                agentPrefab,
                (Random.insideUnitSphere * startingCount * AgentDenstity),
                Quaternion.Euler(Vector3.forward * Random.Range(0, 360)),
                transform

                );
            NewAgent.name = "Agent" + i;

            //Now it knows what flock it belong to
            NewAgent.initialize(this);
            agents3D.Add(NewAgent);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Iterate through agents 
        foreach (FlockAgent3D agent in agents3D)
        {
            //What is inside the agent radius
            List<Transform> contex = GetNearbyObjects(agent);




            Vector3 move = behaviour.CalculateMove(agent, contex, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;

            }
            agent.Move(move);

        }
    }


    List<Transform> GetNearbyObjects(FlockAgent3D agent)
    {
        List<Transform> context = new List<Transform>();

        //gets all nearby objects inside the a circle of the agent. To do this in 3d Use collider 3d and a overlapSphereall
        Collider[] contextCollider = Physics.OverlapSphere(agent.transform.position, neighborRadius);

        //Put all the colliders found inside the circle and put itside the list
        foreach (Collider c in contextCollider)
        {
            //if the collider isnt our own collider 
            if (c != agent.AgentCollider)
            {
                //adds the transform of the collider found inside the neighborRadius
                context.Add(c.transform);
            }
        }
        return context;
    }
}
