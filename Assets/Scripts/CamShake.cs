using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float shakePow = 3f;
    public float shakeTime = 1;
    Shooting shooting;

    Vector3 firstPos;

    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.localPosition;
        shooting = FindObjectOfType<Shooting>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shake();  
    }

    void Shake()
    {
        transform.localPosition += Random.insideUnitSphere + firstPos;
    }
}
