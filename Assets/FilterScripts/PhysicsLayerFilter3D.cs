using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock3D/filter/Physics Layer")]
public class PhysicsLayerFilter3D : ContexFilter3D
{

    //LayerMask is a convient way of acessing the physics layer in the inspector 
    public LayerMask mask;

    public override List<Transform> Filter(FlockAgent3D agent, List<Transform> original)
    {

        List<Transform> Filtered = new List<Transform>();



        foreach (Transform item in original)
        {

            //if the item is on one of the mask layers.
            if (mask == (mask | (1 << item.gameObject.layer)))
            {

                Filtered.Add(item);
            }

        }

        return Filtered;
    }
}
