using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int PlayerScore;
    public Text PlayerScoreTextInCanvas;


    void Start()
    {
        PlayerScoreTextInCanvas.text = "PONTUA��O: " + PlayerScore;
    }
    void Awake()
    {
        Instance = this;
    }

    public void RecordPlus(int _pointsForWin)
    {
        PlayerScore += _pointsForWin;
        PlayerScoreTextInCanvas.text = "PONTUA��O: " + PlayerScore;
    }
}
