using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]

public class AlignmentBehaviour : FlockBehaviour
{
    //Finds the middle point between neighbours and tries to move there  
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        //If no neighbors, maintain current heading 
        if (context.Count == 0)
           return agent.transform.up;

        //Add all points together and avarage
        Vector2 AlignmentMove = Vector2.zero;
        foreach (Transform item in context)
        {
            AlignmentMove += (Vector2)item.transform.up;
        }

        //returns a normalized value
        AlignmentMove /= context.Count;

        return AlignmentMove;

    }

}
