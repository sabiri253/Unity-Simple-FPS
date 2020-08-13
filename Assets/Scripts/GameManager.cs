using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FpsControll player_Pos;
    Vector3 player_FirstPos;

    private void Start()
    {
        player_Pos.transform.position = transform.position;
        player_FirstPos = player_Pos.transform.position;
    }

    private void Update()
    {
        if (player_Pos.reset)
            StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.1f);
        player_Pos.transform.position = player_FirstPos;
    }


}
