using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class FlockAgent3D : MonoBehaviour
{
    Flock3D agentFlock3D;
    public Flock3D AgentFlock3D { get { return agentFlock3D; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }



    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    public void initialize(Flock3D flock)
    {
        agentFlock3D = flock;

    }

    public void Move(Vector3 velocity)
    {

        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

}
