using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RayCastDetection_TEST : MonoBehaviour
{
     
     void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit,Mathf.Infinity))
        {
            Debug.DrawRay(transform.position,transform.forward, Color.blue);
                Debug.Log(hit.transform.name);
        }
    }
}
