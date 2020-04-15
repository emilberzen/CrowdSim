using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]

public class CohesianBehaviour : FilterFlockBehaviour
{

    //Finds the middle point between neighbours and tries to move there  
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        //If no neighbors return no adjustment 
        if (context.Count == 0)    
            return Vector2.zero;

        //Add all points together and avarage
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> fiteredContex = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in fiteredContex)
        {
            cohesionMove += (Vector2)item.position; 
        }

        cohesionMove /= context.Count;



        //create offset from agent position
        cohesionMove -= (Vector2)agent.transform.position;

        return cohesionMove;
         
    }



}
