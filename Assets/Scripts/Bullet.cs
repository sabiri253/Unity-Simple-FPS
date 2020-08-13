using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float damage = 10;
    public float speed = 30f;
    public GameObject pewEffect;
    public GameObject bloodEffect;
    [SerializeField] public bool hitEnemy = false;

    void Update(){
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Destroy(gameObject, 7);
    }

     void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Box"))
        {
            Instantiate(pewEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            hitEnemy = true;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionExit(Collision collision){
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitEnemy = false;
        }
    }
}