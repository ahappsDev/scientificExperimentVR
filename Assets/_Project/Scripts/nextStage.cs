using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStage : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            gameManager.nextStage();
        }
    }
}
