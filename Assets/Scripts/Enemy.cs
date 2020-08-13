using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav_mesh;

    public Transform target;

    public Collider collider;
    public Collider[] colliders;

    public Rigidbody rb;
    public Animator anim;

    public bool isHitted = false;
    public bool RagdollActiv = false;

    public void Start(){
        nav_mesh = GetComponent<NavMeshAgent>();
        collider = GetComponent<Collider>();
        colliders = GetComponentsInChildren<Collider>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        collider.enabled = false;
    }

    //ACTIVATE RAGDOLL
    public void isRagdoll(bool isRagdoll)
    {
            rb.useGravity = !isRagdoll;
            anim.enabled = !isRagdoll;
            collider.enabled = !isRagdoll;
            isHitted = !isRagdoll;        
    }

    //FOLLOW THE PLAYER
    private void Update(){
        if(!RagdollActiv)
         nav_mesh.SetDestination(target.position);
    }
}