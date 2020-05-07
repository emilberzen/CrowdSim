using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public int numberOfObjects;
    public int currentObjects;
    public GameObject objectToPlace;
    public List<Vector2> objPos = new List<Vector2>();

    private float randomX;
    private float randomZ;
    private SpriteRenderer r;
    public float minDistance = 0.01f; // Each waypoint must be radius 10 apart
    private List<Vector3> waypointPositions = new List<Vector3>();


    void Start()
    {

        r = GetComponent<SpriteRenderer>();

    }
 
    void FixedUpdate()
    {


        RaycastHit hit;

        if (currentObjects <= numberOfObjects)
        {
            
            randomX = Random.Range(r.bounds.min.x, r.bounds.max.x);
            randomZ = Random.Range(r.bounds.min.y, r.bounds.max.y);

            // Cast a ray straight down.
            RaycastHit2D hit2D = Physics2D.Raycast(new Vector3(randomX, randomZ, r.bounds.max.y + 5f), -Vector3.up);
        

            // If it hits something...
            if (hit2D.collider != null)
            {

                         Vector2 hitPos = hit2D.point;
                        bool close = false;
                        foreach (Vector3 wp in waypointPositions) // foreach loop cycles through each type (Vector3) in the list and names it (wp)
                        {
                            if (Vector3.Distance(wp, hitPos) < minDistance) close = true;  // Compares the distance between the random point and each existing waypoint
                        }
                        if (!close) // If the new point is valid add it to the list, instantiate it, and break out of the j-indexed for loop
                        {

                            waypointPositions.Add(hitPos);
                            var newObject = (GameObject)Instantiate(objectToPlace, hit2D.point, Quaternion.identity);
                            newObject.name = currentObjects.ToString();
                            newObject.transform.parent = gameObject.transform;
                            currentObjects += 1;
                            Debug.Log("hello");

                        }



                        /*


                foreach (Vector2 obj in objPos)
                {

                    if (Vector3.Distance(obj, hit2D.point)> 2f)
                    {
                        dist.Add(Vector3.Distance(obj, hit2D.point));

                        if (dist.Min()>3)
                        {


                        }
                        lastPos = hit2D.point;
                        objPos.Add(lastPos);
                        currentObjects += 1; break;
                    }

                }
                */

            }

        }
    }

    void FillList()
    {
       
    }
}
