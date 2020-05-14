using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMouseControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var screenPoint = new Vector3(Input.mousePosition.x/100, Input.mousePosition.y/ 100, Input.mousePosition.z/100);
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        Debug.Log(screenPoint);

    }
}
