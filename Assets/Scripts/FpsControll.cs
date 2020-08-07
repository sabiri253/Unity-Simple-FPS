﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FpsControll : MonoBehaviour
{
    Animator player;
    public int damageValue;
    public GameObject crossHair;

    public float speed = 10f;
    public float jump_Force = 7f;
    public float mouse_Sensetivity = 4f;
    public float gravity = 9f;
    float xRotation = 0;

    CharacterController char_Controll;
    WeaponPickUp pick;

    bool showCrossHair = false;

    Camera cam;

    Vector3 camFirstPos;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start(){
        pick = FindObjectOfType<WeaponPickUp>();

        player = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;

        camFirstPos = transform.position;
        char_Controll = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update(){
        velocity.y -= gravity * Time.deltaTime;
        char_Controll.Move(velocity * Time.deltaTime);
        if (char_Controll.isGrounded)
            velocity.y = -2f;
        CameraRotation();
        PlayerMove();
        Crouch();
        CrossHairDisplay();
    }

    void PlayerMove(){
        float move_Forward = Input.GetAxis("Vertical");
        float move_right = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.Space) && char_Controll.isGrounded)
        {
            velocity.y = jump_Force;
        }
        if (move_right > 0 || move_right < 0 || move_Forward > 0 || move_Forward < 0)
        {
            if(char_Controll.isGrounded)
            {
              player.SetBool("Walking",true);
              if (Input.GetKey(KeyCode.LeftShift))
                 player.SetBool("Running", true);
              if (Input.GetKeyUp(KeyCode.LeftShift))
                 player.SetBool("Running", false);
            }
        }
        else
            player.SetBool("Walking", false);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            speed = 10;
            jump_Force = 11;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            speed = 5;
            jump_Force = 7f;
        }
        Vector3 forward = transform.forward * move_Forward * speed;
        Vector3 left = transform.right * move_right * speed;
        char_Controll.Move((forward + left) * Time.deltaTime);
    }    
    void CameraRotation()
    {
        float x = Input.GetAxis("Mouse X") * mouse_Sensetivity;
        float y = Input.GetAxis("Mouse Y") * mouse_Sensetivity;
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f , 0f);
        transform.Rotate(Vector3.up * x);
    }

    void CrossHairDisplay()
    {
        if (pick.isPicked)
        {
            showCrossHair = true;
        }
        else showCrossHair = false;

        if (showCrossHair) crossHair.SetActive(true);
        else  crossHair.SetActive(false);
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.C))
            player.SetBool("Crouch", true);
        if (Input.GetKeyUp(KeyCode.C))
           player.SetBool("Crouch", false);    
            
    }
}