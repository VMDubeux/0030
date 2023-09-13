using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.CompareTag("Item") && Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved) 
            {
                Vector3 p = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                p.z = transform.position.z;
                transform.position = p;
            }
        }
    }
}
