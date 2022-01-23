using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStage : MonoBehaviour
{
    [SerializeField] private int stage;
    private GameObject go;
    private GameObject parent;
    private GameManager gameManager;

    private void Awake()
    {
        go = GameObject.Find("GameManager");
        gameManager = go.GetComponent<GameManager>();
        parent = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && parent.activeSelf == true) 
        {
            //Debug.Log(parent.name + " " + parent.activeSelf);
            gameManager.nextStage(stage);
        }
    }
}
