using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceHealthBar : MonoBehaviour
{
    public Transform cam;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}