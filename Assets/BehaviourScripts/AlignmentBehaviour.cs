using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]

public class AlignmentBehaviour : FilterFlockBehaviour
{
    //Finds the middle point between neighbours and tries to move there  
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        //If no neighbors, maintain current heading 
        if (context.Count == 0)
           return agent.transform.up;

        //Add all points together and avarage
        Vector2 AlignmentMove = Vector2.zero;
        List<Transform> fiteredContex = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in fiteredContex)
        {
            AlignmentMove += (Vector2)item.transform.up;
        }

        //returns a normalized value
        AlignmentMove /= context.Count;

        return AlignmentMove;

    }

}
