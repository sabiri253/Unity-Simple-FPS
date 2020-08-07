using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthBar;
    public float currValue;
    // Start is called before the first frame update
    void Start(){
        healthBar = GetComponent<Slider>();
    }
    public void Damage(float damage){
        currValue  -= damage;
    }
}          