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
    [SerializeField] private GameObject stage1, stage2, stage3;

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
            if(currentStage==2)
            {
                stage1.SetActive(false);
                stage2.SetActive(true);
            }

            DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 0f, 1);
        });
    }
}
