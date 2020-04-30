using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContexFilter3D : ScriptableObject
{
    public abstract List<Transform> Filter(FlockAgent3D agent, List<Transform> original);


}
