using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBoard;
    private string textsScore = "LAST SCORE: ";
    void Awake()
    {
        textBoard.text = "SCOREBOARD \n -------------- \n BEST SCORE: \n" + PlayerPrefs.GetString("bestScore", "--:--") + " \n LAST SCORE: \n" + PlayerPrefs.GetString("lastScore", "--:--");
    }
}
