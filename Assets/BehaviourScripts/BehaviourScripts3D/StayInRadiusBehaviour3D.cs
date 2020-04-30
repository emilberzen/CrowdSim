using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock3D/Behaviour/StayInRadius3D")]
public class StayInRadiusBehaviour3D : FilterFlockBehaviour3D
{

    public Vector3 center;
    public float radius = 15f;

    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        //How far is the agent from the center and steer towards th center 
        Vector3 centerOffset = center - agent.transform.position;

        //tells us where we are, if t i 0 we are at the center if t is 1 we are at the end of the radius. 
        float t = centerOffset.magnitude / radius;

        //if we are iside the 0.9 radius let the agent continue their journey 
        if(t < 0.9f)
        {
            return Vector3.zero;
        }

        

        return centerOffset*t*t;


           
    }



}
