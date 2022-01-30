using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBoard;
    void Awake()
    {
        textBoard.text = "SCOREBOARD \n -------------- \n BEST SCORE: \n" + PlayerPrefs.GetString("bestScore", "--:--") + " \n \n LAST SCORE: \n" + PlayerPrefs.GetString("lastScore", "--:--");
    }
}
