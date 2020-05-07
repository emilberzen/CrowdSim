using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{

    public GameObject home;
    private GameObject HomePos;
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
    }
}
