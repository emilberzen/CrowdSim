using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]


public class AvoidanceBehaviour : FilterFlockBehaviour
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
        List<Transform> fiteredContex = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in fiteredContex)
        {


            Vector2 closestPoint = item.gameObject.GetComponent<Collider2D>().ClosestPoint(agent.transform.position);

            //squared distance between the item and the agent 
            if (Vector2.SqrMagnitude(closestPoint - (Vector2)agent.transform.position) < flock.SquareAvoidanceRadius )
            {
                //gives the offset
                AvoidanceMove +=((Vector2)agent.transform.position - closestPoint);

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
