using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock3D/Behaviour/Alignment3D")]

public class AlignmentBehaviour3D : FilterFlockBehaviour3D
{
    //Finds the middle point between neighbours and tries to move there  
    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {

        //If no neighbors, maintain current heading 
        if (context.Count == 0)
            return agent.transform.up;

        //Add all points together and avarage
        Vector3 AlignmentMove = Vector3.zero;
        List<Transform> fiteredContex = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in fiteredContex)
        {
            AlignmentMove += (Vector3)item.transform.up;
        }

        //returns a normalized value
        AlignmentMove /= context.Count;

        return AlignmentMove;

    }
}
