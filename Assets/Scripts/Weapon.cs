using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public WeaponPickUp weapon_Pick;

    public GameObject crossHair;

    public float rotationSpeed = 10f;

    public string warningText;

    public Text Ammo;
    public Text warning;

    [Range(10, 60)]
    public int bulletCount = 10;
    public int firstBulletCount;

    public bool isPicked = false;
    public bool isHolded = false;
    public bool isDropped = false;

    public void Start()
    {
        firstBulletCount = bulletCount;
        warning.gameObject.SetActive(false);
    }
    public void Update(){
        checkIfPicked();
        RotatingGun();
        DroppingGun();
    }

    //DROPP THE GUN
    public void DroppingGun(){
         weapon_Pick.GunDropped(gameObject);
         weapon_Pick.EmptyListFromGun(gameObject);
    }

    //ROTATE WEAPON WHILE IT'S NOT PICKED
    public void RotatingGun(){
        if (!isPicked){
            Ammo.gameObject.SetActive(false);
            if (this.gameObject.tag == "Gun")
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            if (this.gameObject.tag == "MachineGun"){
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            }
        }
    }

    //CHECK IF PICKED
    public void checkIfPicked(){
        if (isPicked){
            //gameObject.SetActive(false);
            Ammo.gameObject.SetActive(true);
            Ammo.text = "Ammo" + bulletCount;
            if(!isHolded && weapon_Pick.weapons.Count <= 3){
             weapon_Pick.weapons.Add(gameObject);
             weapon_Pick.pickSound.time = 1.2f;
             weapon_Pick.pickSound.Play();
             weapon_Pick.GunPicked(gameObject);
             weapon_Pick.GunDropped(gameObject);
            }
        }
    }

    //Enable CrossHair
    private void OnEnable(){
        if (isPicked){
            crossHair.SetActive(true);
            isHolded = true;
        } 
    }

    //Disable CrossHair
    private void OnDisable(){
        if(isPicked){
          crossHair.SetActive(false);
          isHolded = false;
        }
    }

    private void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("Player")){
            isPicked = true;
         if (weapon_Pick.weapons.Count > 3){
            warning.text = warningText;
            warning.gameObject.SetActive(true);            
            StartCoroutine("DisableText");
         }
        }
    }
    IEnumerator DisableText(){
        yield return new WaitForSeconds(3);
        warning.gameObject.SetActive(false);
    }
}