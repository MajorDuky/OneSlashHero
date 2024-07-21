using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text score;

    public void UpdateScore(int value)
    {
        score.text = value.ToString();
    }
}
