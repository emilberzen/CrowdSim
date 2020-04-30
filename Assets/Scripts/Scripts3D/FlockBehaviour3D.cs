using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviour3D : ScriptableObject
{
    public abstract Vector3 CalculateMove(FlockAgent3D agent3D, List<Transform> context3D, Flock3D flock3D);

}
