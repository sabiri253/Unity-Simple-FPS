using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour{
    public List<GameObject> weapons;

    public Shooting shoot;
    public GameObject gunHold;
    public GameObject gun;

    public bool isPicked = false;

    // Update is called once per frame
    void Update()   {
        GunPicked();
        GunDropped();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gun")
        {
            isPicked = true;           
        }

    }
    void GunPicked(){
        if(isPicked){
            GunHolded(gun);
            shoot.Ammo.gameObject.SetActive(true);
        }
    }
   void GunHolded(GameObject weapon){
        weapon.transform.parent = gunHold.transform;
        weapon.transform.position = gunHold.transform.position;
        weapon.transform.eulerAngles = gunHold.transform.eulerAngles;           
    }
    void GunDropped(){
        if (Input.GetKey(KeyCode.P) && isPicked)
        {
            gun.transform.parent = null;
            Vector3 resetAngle = new Vector3(0,0,0);
            Vector3 offset = new Vector3(0.4f,0,0.4f);
            gun.transform.eulerAngles = resetAngle;
            gun.transform.position += offset;            
            shoot.Ammo.gameObject.SetActive(false);

            isPicked = false;
        }        
    }
}