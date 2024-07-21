using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Button replayBtn;

    public void DisplayScoreText(int value)
    {
        scoreText.text = value.ToString();
        replayBtn.Select();

    }
}
