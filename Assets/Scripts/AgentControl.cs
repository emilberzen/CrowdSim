using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AgentControl : MonoBehaviour
{

    private GameObject home;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        agent = this.GetComponent<NavMeshAgent>();
        home = GameObject.Find(this.name.Remove(0, 1));
        agent.SetDestination(home.transform.position);

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude < 0.5f)
                {
                    transform.DOScaleY(5, 1);
                }

            }
            else
            {

                transform.DOScaleY(2, 1);

            }
        }


    }
}
