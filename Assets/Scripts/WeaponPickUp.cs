using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour {
    public List<GameObject> weapons;
    public AudioSource pickSound;

    public Weapon weapon_;

    public GameObject gunHold;

    public int SelectedWeapon = 0;

    public bool picked = false;

   private void Start(){
        weapons = new List<GameObject>();
    }

    // Update is called once per frame
    public void Update() {
        SelectWeapon();
        weapon_ = FindObjectOfType<Weapon>();
    }

    //WEAPON SWITCH
    public void SelectWeapon(){
        int i = 0;
        if (Input.GetAxis("Mouse ScrollWheel") > 0){
            if (SelectedWeapon >= weapons.Count - 1)
                SelectedWeapon = weapons.Count - 1;
            else
              SelectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0){
            if (SelectedWeapon <= 0)
                SelectedWeapon = 0;
            else
                SelectedWeapon--;
        }            
        foreach(GameObject weapon in weapons)
        {
            if (i == SelectedWeapon)
                weapon.gameObject.SetActive(true);
            else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
    //REMOVE THE SELECTED WEAPON FROM THE LIST
    public void EmptyListFromGun(GameObject weapon_To_Remove){
       if (weapon_.isDropped){
           weapons.Remove(weapon_To_Remove);
            weapon_.isDropped = false;
        }
    }

    //PICK THE WEAPON
   public void GunPicked(GameObject weapon){
        weapon.transform.parent = gunHold.transform;
        weapon.transform.position = gunHold.transform.position;
        weapon.transform.eulerAngles = gunHold.transform.eulerAngles;
    }
    //DROP THE WEAPON
    public void GunDropped(GameObject weapon){
        if (Input.GetKey(KeyCode.P) && weapon_.isPicked && weapon_.isHolded){
            weapon.transform.parent = null;
            Vector3 resetAngle = new Vector3(0,0,0);
            Vector3 offset = new Vector3(0.4f,0,0.4f);
            weapon.transform.eulerAngles = resetAngle;
            weapon.transform.position += offset;            
            weapon_.Ammo.gameObject.SetActive(false);
            weapon_.isPicked  = false;
            weapon_.isHolded  = false;
            weapon_.isDropped = true;
        }        
    }
}