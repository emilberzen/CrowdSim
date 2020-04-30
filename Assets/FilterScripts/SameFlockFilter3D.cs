using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock3D/filter/Same Flock")]
public class SameFlockFilter3D : ContexFilter3D
{
    public override List<Transform> Filter(FlockAgent3D agent, List<Transform> original)
    {

        List<Transform> Filtered = new List<Transform>();



        foreach(Transform item in original) {
            FlockAgent3D itemAgent = item.GetComponent<FlockAgent3D>();
            
            
            //If there are a flock component attached and they are in the same flock then add it to the fiterd list
               if(itemAgent != null && itemAgent.AgentFlock3D == agent.AgentFlock3D)
            {

                Filtered.Add(item);
            }
        }

        return Filtered;
    }
}
