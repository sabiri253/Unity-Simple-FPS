using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    WeaponPickUp pickED;

    public AudioSource shoot;

    public GameObject bullet;
    public GameObject shootSound;
    public GameObject start;
    public GameObject bloodEffect;

    public int currCount;

    public bool isShooting = false;
    public bool enemyHitted = false;

    public Weapon weapon;

    public Text reloadText; 

    public float time_Between_Shots = 1;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
        currCount = weapon.bulletCount;
        weapon.Ammo.text += currCount;
        weapon.Ammo.gameObject.SetActive(false);
        reloadText.gameObject.SetActive(false);
        time_Between_Shots = 0;
        pickED = FindObjectOfType<WeaponPickUp>();
    }

    // Update is called once per frame
    void Update(){
        if (weapon.isHolded)
            Shoot();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<Enemy>().isRagdoll(true);
            FindObjectOfType<Enemy>().RagdollActiv = true;
        }
    }

    public void Shoot(){
        isShooting = false;        
        if (Input.GetKeyDown(KeyCode.Mouse0) && weapon.isPicked && time_Between_Shots <= 0 && currCount > 0 ){
            isShooting = true;
            shoot.Play();
            ////RAYCAST SHOOT !!!!!!
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.transform.name);
                if (hit.rigidbody != null)
                {
                    Instantiate(bloodEffect, hit.point, Quaternion.identity);
                    hit.rigidbody.AddForce(-hit.normal * 1000);
                    if (hit.transform.tag == "Enemy")
                    {
                     hit.transform.GetComponent<Enemy>().isRagdoll(true);

                    }
                }
            }
            Instantiate(bullet, start.transform.position, start.transform.rotation);
            Instantiate(shootSound, start.transform.position, start.transform.rotation);
            time_Between_Shots = 1.1f;
            currCount--;
            weapon.Ammo.text += currCount;
        }         
        if (currCount > 0){
            reloadText.gameObject.SetActive(false);
        }
        if (currCount <= 0){
            if (weapon.isPicked && (currCount <= 0 || currCount < weapon.bulletCount)){
                reloadText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R) && currCount < weapon.bulletCount){
                    currCount = weapon.firstBulletCount;
                    pickED.pickSound.time = 1.2f;
                    pickED.pickSound.Play();
                }
            }
        }
        if (time_Between_Shots <= 0)
            time_Between_Shots = 0;
        time_Between_Shots -= 0.09f;
    }
}