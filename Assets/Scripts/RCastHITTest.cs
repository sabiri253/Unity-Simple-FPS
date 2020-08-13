using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCastHITTest : MonoBehaviour
{
    public bool enemyHitted = false;
    public AudioSource shoot;

    Enemy enemy;

    public GameObject bloodEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void Shoot(){
        shoot.Play();
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit , Mathf.Infinity)){
            Debug.Log(hit.transform.name);
            if (hit.rigidbody != null)
            {
                Instantiate(bloodEffect, hit.point, Quaternion.identity);
                hit.rigidbody.AddForce(-hit.normal * 1000);
                enemyHitted = true;
            }
        }
    }
}