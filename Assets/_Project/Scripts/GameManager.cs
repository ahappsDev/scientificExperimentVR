using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    protected Health _playerHealth;
    protected bool win = false;
    public Image fadeOut;
    [SerializeField] TextMeshProUGUI TextGameOver, TextWin, TextRestart;

    void Awake()
    {
        _playerHealth = Player.instance.GetComponent<Health>();
    }

    private void Update()
    {
        //Canvas to game over 
        if (!_playerHealth.IsAlive)
        {
            fadeOut.DOColor(new Color(0, 0, 0, 1f), 5f);
            TextGameOver.DOColor(new Color(1f, 1f, 1f, 1f), 5f);
            TextRestart.DOColor(new Color(1f, 1f, 1f, 1f), 5f);
            if (Input.GetKeyDown(KeyCode.Space)) 
                SceneManager.LoadScene(0);
        }
        //Canvas to game win
        if (win)
        {
            fadeOut.DOColor(new Color(0, 0, 0, 1f), 5f);
            TextWin.DOColor(new Color(1f, 1f, 1f, 1f), 5f);
            TextRestart.DOColor(new Color(1f, 1f, 1f, 1f), 5f);
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(0);
        }
    }
    public void setWin()
    {
        win = true;
    }
}
