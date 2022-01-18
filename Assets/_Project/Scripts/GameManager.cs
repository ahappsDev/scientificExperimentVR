using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    //protected Health _playerHealth;
    //protected bool win = false;
    //[SerializeField] TextMeshProUGUI TextGameOver, TextWin, TextRestart;

    private int currentStage = 1;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Volume fadeToBlackVolume;

    void Awake()
    {
        //_playerHealth = Player.instance.GetComponent<Health>();
    }

    private void Update()
    {
       
    }
    public void nextStage()
    {
        currentStage++;
        loadStage();
    }

    private void loadStage()
    {
        DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 1f, 1).OnComplete(() =>
        {
            transformPlayer.position = new Vector3(0,0,0);
            DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 0f, 1);
        });
    }
}
