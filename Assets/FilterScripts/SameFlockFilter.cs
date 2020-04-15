using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/filter/Same Flock")]
public class SameFlockFilter : ContexFilter
{
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {

        List<Transform> Filtered = new List<Transform>();



        foreach(Transform item in original) {
            FlockAgent itemAgent = item.GetComponent<FlockAgent>();
            
            
            //If there are a flock component attached and they are in the same flock then add it to the fiterd list
               if(itemAgent != null && itemAgent.AgentFlock == agent.AgentFlock)
            {

                Filtered.Add(item);
            }
        }

        return Filtered;
    }
}
