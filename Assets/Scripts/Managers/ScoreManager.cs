using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public int score;
    [SerializeField] private ScoreUI scoreUI;

    private void OnEnable()
    {
        ComboKillManager.comboCountUpdated.AddListener(AnswerToEnemySlay);
    }

    private void AnswerToEnemySlay(int comboCount)
    {
        score += 100 * comboCount;
        scoreUI.UpdateScore(score);
    }
}
