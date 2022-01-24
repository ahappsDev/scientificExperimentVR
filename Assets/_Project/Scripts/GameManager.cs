using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBoard;
    private TextMeshProUGUI textClock;
    private GameObject[] clocks;
    private float currentTime = 0f;
    private string textTime = "00:00";

    private string board2 = "Stage 2 - Dexterity \n \n This test will test the user's dexterity. \n \n To do this, using the blower, you will have to look in the sand for the key to open the door.";
    private string board3 = "Stage 3 - Hardness \n \n This test will test the toughness of the user. \n \n To do this, using the sword, you will have to kill the robot to end the experiment.";

    private int currentStage = 1;
    private string bestScore;
    private GameObject orb;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Volume fadeToBlackVolume;

    [SerializeField] private GameObject stage1, stage2, stage3;
    [SerializeField] private GameObject portal1, portal2, portal3;
    [SerializeField] private Elevator elevator;

    private void Awake()
    {
        clocks = GameObject.FindGameObjectsWithTag("Clock");
        bestScore = PlayerPrefs.GetString("bestScore", "--:--");
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        textTime = updateTime();
        foreach (GameObject clock in clocks)
        {
            textClock = clock.GetComponent<TextMeshProUGUI>();
            textClock.text = textTime;
        }
    }

    private string updateTime()
    {
        int min = 0;
        int sec = 0;
        string time;

        if (currentTime < 0)
            currentTime = 0;

        min = (int)currentTime / 60;
        sec = (int)currentTime % 60;

        time = min.ToString("00") + ":" +sec.ToString("00");

        return time;
    }

    public void nextStage(int _stage)
    {
        currentStage = _stage;
        StartCoroutine(loadStage()); ;
    }

    public IEnumerator loadStage()
    {
        //Teleport to init ecene
        DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 1f, 1).OnComplete(() =>
        {
            transformPlayer.position = new Vector3(0,0,0);
            DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 0f, 1);
        });

        // Change to stage 2
        if (currentStage == 2)
        {
            stage2.SetActive(false);
            portal2.SetActive(false);

            textBoard.text = board2;
            yield return new WaitForSeconds(1f);

            stage1.SetActive(true);
            portal1.SetActive(true);

            elevator.setHeight(4.9f);
        }
        // Change to stage 3
        if (currentStage == 3)
        {

            stage1.SetActive(false);
            portal1.SetActive(false);

            orb = GameObject.FindWithTag("Orb");
            orb.SetActive(false);

            textBoard.text = board3;
            yield return new WaitForSeconds(1f);

            portal3.SetActive(true);
            stage3.SetActive(true);

            elevator.setHeight(4.9f);
        }
        // Restart
        if (currentStage == 4)
        {
            PlayerPrefs.SetString("lastScore", textClock.text);
            string[] timeStrings = textClock.text.Split(':');
            string[] timeBestStrings = bestScore.Split(':');
            if (bestScore == "--:--")
                PlayerPrefs.SetString("bestScore", textClock.text);
            else
            {
                if(Int16.Parse(timeStrings[0]) < Int16.Parse(timeBestStrings[0]))
                    PlayerPrefs.SetString("bestScore", textClock.text);
                else
                    if ((Int16.Parse(timeStrings[0]) == Int16.Parse(timeBestStrings[0])) && Int16.Parse(timeStrings[1]) < Int16.Parse(timeBestStrings[1]))
                    {
                        PlayerPrefs.SetString("bestScore", textClock.text);
                    }
            }
            SceneManager.LoadScene("Menu");
        }
        yield return new WaitForSeconds(.1f);

    }
}
