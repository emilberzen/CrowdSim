using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behaviour/Stay in Radius")]
public class StayInRadiusBehaviour : FilterFlockBehaviour
{

    public Vector2 center;
    public float radius = 0f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //How far is the agent from the center and steer towards th center 


        Vector2 centerOffset = center - (Vector2)agent.transform.position;

        //tells us where we are, if t i 0 we are at the center if t is 1 we are at the end of the radius. 
        float t = centerOffset.magnitude / radius;

        //if we are iside the 0.9 radius let the agent continue their journey 
        if(t < 0.9f)
        {
            return Vector2.zero;
        }

        return centerOffset * t * t; 
           
    }


}
