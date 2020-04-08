using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]


public class AvoidanceBehaviour : FlockBehaviour
{
    //Finds the middle point between neighbours and tries to move there  
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        //If no neighbors return no adjustment 
        if (context.Count == 0)
            return Vector2.zero;

        //Add all points together and avarage
        Vector2 AvoidanceMove = Vector2.zero;

        //How many inside the avodance radius.
        int nAvoid = 0; 

        foreach (Transform item in context)
        {
             //squared distance between the item and the agent 
            if(Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius )
            {
                //gives the offset
                AvoidanceMove += (Vector2)(agent.transform.position - item.position);

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
