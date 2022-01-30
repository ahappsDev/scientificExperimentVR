using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablePortal : MonoBehaviour
{
    [SerializeField] private GameObject teleport;
    // Start is called before the first frame update
    void OnEnable()
    {
        teleport.SetActive(true);
    }
}
