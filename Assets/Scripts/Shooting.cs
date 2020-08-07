using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    WeaponPickUp pickED;
    Animator gun;

    public GameObject bullet;
    public GameObject start;

    public int bulletCount = 20;

    public bool isShooting = false;

    public Text Ammo;
    public Text reloadText; 

    public float time_Between_Shots = 1;

    // Start is called before the first frame update
    void Start()
    {
        Ammo.text = "Bullet: " + bulletCount;
        Ammo.gameObject.SetActive(false);
        reloadText.gameObject.SetActive(false);
        gun = GetComponent<Animator>();
        time_Between_Shots = 0;
        pickED = FindObjectOfType<WeaponPickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        isShooting = false;
        if (bulletCount > 0){
            gun.SetBool("empty", false);
            reloadText.gameObject.SetActive(false);
        }
        if (bulletCount <= 0){
            gun.SetBool("empty", true);
            if (pickED.isPicked){
                reloadText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                    bulletCount = 20;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && pickED.isPicked && time_Between_Shots <= 0 && bulletCount > 0 ){
            isShooting = true;
            gun.SetTrigger("shoot");
            Instantiate(bullet, start.transform.position, start.transform.rotation);
            time_Between_Shots = 1.1f;
            bulletCount--;
        }
        Ammo.text = "Bullet: " + bulletCount;
        if (time_Between_Shots <= 0)
            time_Between_Shots = 0;
        time_Between_Shots -= 0.06f;
    }
}