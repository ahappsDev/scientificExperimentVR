using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startController : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("Laboratory");
    }
}