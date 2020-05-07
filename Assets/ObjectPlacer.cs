using System.Collections;
using System.Collections.Generic;
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
    private Vector2 lastPos;
    private float dist;
    void Start()
    {

        r = GetComponent<SpriteRenderer>();
        lastPos = new Vector2(0, 0);
        objPos.Add(lastPos);

    }
 
    void FixedUpdate()
    {


        RaycastHit hit;

        if (currentObjects <= numberOfObjects)
        {
            
            randomX = Random.Range(r.bounds.min.x, r.bounds.max.x);
            randomZ = Random.Range(r.bounds.min.y, r.bounds.max.y);


            /*
            if (Physics.Raycast(new Vector3(randomX, r.bounds.max.y + 5f, randomZ), -Vector3.up, out hit))
            {
                Instantiate(objectToPlace, hit.point, Quaternion.identity);
                currentObjects += 1;
                Debug.Log("hello");    

            }
                */

            // Cast a ray straight down.

            RaycastHit2D hit2D = Physics2D.Raycast(new Vector3(randomX, randomZ, r.bounds.max.y + 5f), -Vector3.up);
        

            // If it hits something...
            
            if (hit2D.collider != null)
            {
                
                for (int i = 0; i < objPos.Count; i++)
                {
                    
                        if (Vector2.Distance(hit2D.point, lastPos) <3)
                        {
                        Instantiate(objectToPlace, hit2D.point, Quaternion.identity);

                        lastPos = hit2D.point;
                        objPos.Add(lastPos);
                        currentObjects += 1;

                    }
                }


            }

        }
    }
}
