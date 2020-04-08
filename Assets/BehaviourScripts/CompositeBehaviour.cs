using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]


public class CompositeBehaviour : FlockBehaviour
{

    public FlockBehaviour[] behaviours;
    public float[] weights;



    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Handle data missmatch 
        if (weights.Length != behaviours.Length)
        {

            Debug.Log("Error: Data missmactch in" + name, this);
            return Vector2.zero;
        }

        // setup Move
        Vector2 move = Vector2.zero;

        //iterate through behaviours 
        for (int i = 0; i < behaviours.Length; i++)
        {
            //middle man passing through the different beaviours 
            Vector2 partialMove = behaviours[i].CalculateMove(agent, context, flock) * weights[i];

            //is some movement being returned? 
            if(partialMove != Vector2.zero)
            {

                //does this movent exceed the wieight?
                if(partialMove.sqrMagnitude > weights[i]* weights[i])
                {
                    //if it does, normalize it back to magnitude of 1 and multiply it by the weigth so it set perfectly at the maximum of the weight
                    partialMove.Normalize();
                    partialMove *= weights[i];


                }  

                move += partialMove; 

            }
        }

        return move; 
    }
}
