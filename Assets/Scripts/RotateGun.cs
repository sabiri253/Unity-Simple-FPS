using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    [SerializeField]float rotationSpeed = 10f;

    public WeaponPickUp pick_State;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pick_State.isPicked)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
