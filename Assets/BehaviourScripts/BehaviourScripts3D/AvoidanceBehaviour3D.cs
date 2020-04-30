using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock3D/Behaviour/Avoidance3D")]


public class AvoidanceBehaviour3D : FilterFlockBehaviour3D
{
    //Finds the middle point between neighbours and tries to move there  
    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {

        //If no neighbors return no adjustment 
        if (context.Count == 0)
            return Vector3.zero;

        //Add all points together and avarage
        Vector3 AvoidanceMove = Vector3.zero;

        //How many inside the avodance radius.
        int nAvoid = 0;
        List<Transform> fiteredContex = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in fiteredContex)
        {


            Vector3 closestPoint = item.gameObject.GetComponent<Collider>().ClosestPoint(agent.transform.position);

            //squared distance between the item and the agent 
            if (Vector3.SqrMagnitude(closestPoint - agent.transform.position) < flock.SquareAvoidanceRadius )
            {
                //gives the offset
                AvoidanceMove += (agent.transform.position - closestPoint);

                //adds 
                nAvoid++;

            }
        }

        if(nAvoid > 0)
        {
            AvoidanceMove /= nAvoid;
        }

        return AvoidanceMove;

    }

}
