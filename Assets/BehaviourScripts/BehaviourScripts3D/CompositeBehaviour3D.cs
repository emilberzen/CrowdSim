using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock3D/Behaviour/Composite3D")]


public class CompositeBehaviour3D : FilterFlockBehaviour3D
{

    public FlockBehaviour3D[] behaviours;
    public float[] weights;



    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        //Handle data missmatch 
        if (weights.Length != behaviours.Length)
        {

            Debug.Log("Error: Data missmactch in" + name, this);
            return Vector3.zero;
        }

        // setup Move
        Vector3 move = Vector3.zero;

        //iterate through behaviours 
        for (int i = 0; i < behaviours.Length; i++)
        {
            //middle man passing through the different beaviours 
            Vector3 partialMove = behaviours[i].CalculateMove(agent, context, flock) * weights[i];


            //is some movement being returned? 
            if (partialMove != Vector3.zero)
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
