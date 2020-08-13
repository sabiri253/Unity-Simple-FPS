using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SlowMotionEffect : MonoBehaviour
{
    public List<Image> chances = new List<Image>();

    public Slider slowMotionDuration;

    public AudioSource slowMotionSound;

    public float timeOfSlowMo = 4;

    public bool isDecreasing = false;

    private void Start()
    {
        slowMotionDuration.gameObject.SetActive(false);
        slowMotionDuration.maxValue = timeOfSlowMo;
        slowMotionDuration.value = timeOfSlowMo;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDecreasing)
        {
            slowMotionDuration.gameObject.SetActive(true);
            if (timeOfSlowMo >= 0){
                Time.timeScale = 0.3f;
                timeOfSlowMo -= Time.deltaTime / 2;               
                slowMotionDuration.value = timeOfSlowMo;            
            }
            if (timeOfSlowMo < 0){
                isDecreasing = false;
                timeOfSlowMo = 1;
                slowMotionDuration.value = timeOfSlowMo;            
            }
        }

        if (!isDecreasing){
            slowMotionSound.Stop();
            Time.timeScale = 1;
            slowMotionDuration.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.L) && !isDecreasing){
           slowMotionSound.time = 1;
           slowMotionSound.Play();
           isDecreasing = true;
        }
    }
}