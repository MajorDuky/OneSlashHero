using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text bonusMalusText;

    public void DecreaseTimer(float value)
    {
        int displayedValue = Mathf.RoundToInt(value);
        int finalDisplayValue = displayedValue <= 0 ? 0 : displayedValue;
        timerText.text = displayedValue.ToString();
    }

    public void BonusMalus(float value)
    {
        bonusMalusText.gameObject.SetActive(true);
        if (value < 0)
        {
            bonusMalusText.color = Color.red; 
        }
        else
        {
            bonusMalusText.color = Color.green;
        }
        bonusMalusText.text = value.ToString();
        StartCoroutine(BonusMalusCoroutine());
    }

    private IEnumerator BonusMalusCoroutine()
    {
        yield return new WaitForSeconds(1f);
        bonusMalusText.gameObject.SetActive(false);
    }
}
