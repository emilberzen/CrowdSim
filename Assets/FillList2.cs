using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillList2 : MonoBehaviour
{
    public GameObject waypoint;
    public int waypointNumber = 10;
    public float minDistance = 10f; // Each waypoint must be radius 10 apart
    private List<Vector3> waypointPositions = new List<Vector3>();
    void Start()
    {
        FillList();
    }

    void FillList()
    {
        for (int i = 0; i < waypointNumber; i++)
        {
            for (int j = 0; j < 50; j++) // Gets a new random position until a valid one is found, ideally runs once
            {
                Vector3 randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
                bool close = false;
                foreach (Vector3 wp in waypointPositions) // foreach loop cycles through each type (Vector3) in the list and names it (wp)
                {
                    if (Vector3.Distance(wp, randomPosition) < minDistance) close = true;  // Compares the distance between the random point and each existing waypoint
                }
                if (!close) // If the new point is valid add it to the list, instantiate it, and break out of the j-indexed for loop
                {
                    waypointPositions.Add(randomPosition);
                    Instantiate(waypoint, randomPosition, Quaternion.identity);
                    Debug.Log("hello");
                    break;
                }
            }
        }
    }
}