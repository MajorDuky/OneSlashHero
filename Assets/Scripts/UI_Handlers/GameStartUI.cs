using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartUI : MonoBehaviour
{
    public RectTransform gameStartUI;
    public TMP_Text countdownText;


    public void GameStartUISequence(float countdownTimer)
    {
        StartCoroutine(GameStartCoroutine(countdownTimer));
    }

    private IEnumerator GameStartCoroutine(float countdownTimer)
    {
        while(!GlobalParametersManager.instance.isGameOn)
        {
            countdownText.text = countdownTimer.ToString();
            yield return new WaitForSeconds(1);
            countdownTimer--;
            if(countdownTimer == 0)
            { 
                GlobalParametersManager.instance.isGameOn = true;
            }
        }
    }
}
