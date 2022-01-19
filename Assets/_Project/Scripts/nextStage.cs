using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStage : MonoBehaviour
{
    private GameObject go;
    private GameManager gameManager;

    private void Awake()
    {
        go = GameObject.Find("GameManager");
        gameManager = go.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            gameManager.nextStage();
        }
    }
}
