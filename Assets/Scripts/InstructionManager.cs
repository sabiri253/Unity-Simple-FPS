using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public Text Instruct;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(InstrucEnab());
    }

    IEnumerator InstrucEnab()
    {
        yield return new WaitForSeconds(1f);
        Instruct.gameObject.SetActive(true);
    }
}
