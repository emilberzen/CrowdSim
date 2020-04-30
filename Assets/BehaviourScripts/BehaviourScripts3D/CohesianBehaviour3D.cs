using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Flock3D/Behaviour/Cohesion3D")]

public class CohesianBehaviour3D : FilterFlockBehaviour3D
{

    //Finds the middle point between neighbours and tries to move there  
    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {

        //If no neighbors return no adjustment 
        if (context.Count == 0)    
            return Vector3.zero;

        //Add all points together and avarage
        Vector3 cohesionMove = Vector3.zero;
        List<Transform> fiteredContex = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in fiteredContex) 
        {
            cohesionMove += item.position; 
        }

        cohesionMove /= context.Count;



        //create offset from agent position
        cohesionMove -= (Vector3)agent.transform.position;

        return cohesionMove;
         
    }



}
