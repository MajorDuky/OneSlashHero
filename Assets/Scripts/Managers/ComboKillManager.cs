using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComboKillManager : MonoBehaviour
{
    public static ComboUpdatedAfterKillEvent comboCountUpdated = new ComboUpdatedAfterKillEvent();
    [HideInInspector] public int comboKillCount;
    private float comboTimeLeft;
    private bool isComboOn;
    [SerializeField] private ComboKillUI comboKillUI;

    private void OnEnable()
    {
        SpawnerManager.onEnemySlay.AddListener(AnswerToEnemySlay);
        comboTimeLeft = 4f;
        isComboOn = false;
    }

    private void AnswerToEnemySlay()
    {
        
        if (!isComboOn)
        {
            comboKillUI.gameObject.SetActive(true);
            isComboOn = true;
        }
        comboKillCount++;
        comboCountUpdated.Invoke(comboKillCount);
        comboTimeLeft = 4f;
        comboKillUI.ChainKill(comboKillCount);

    }

    // Update is called once per frame
    void Update()
    {
        if (comboKillCount > 0 && isComboOn)
        {
            comboTimeLeft -= Time.deltaTime;
            comboKillUI.UpdateChainKillSlider(comboTimeLeft);
        }
        
        if (comboTimeLeft <= 0 && isComboOn)
        {
            comboKillUI.gameObject.SetActive(false);
            isComboOn = false;
            comboTimeLeft = 4f;
            comboKillCount = 0;
        }
    }
}

public class ComboUpdatedAfterKillEvent : UnityEvent<int> { }
