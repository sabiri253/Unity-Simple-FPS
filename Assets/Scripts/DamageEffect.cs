using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public GameObject[] splashes;

    void Start()
    {
        splashes = new GameObject[transform.childCount];
        for (int i = 0; i < splashes.Length; i++)
        {
            splashes[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        Invoke("effect" , 1f);
    }


    IEnumerator effect()
    {
        bool active = false;

        int index = Random.Range(0, splashes.Length);

        splashes[index].SetActive(true);
        yield return new WaitForSeconds(0.1f);

        splashes[index].SetActive(false);
    }

}
