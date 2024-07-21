using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    public float timeLeft;
    public float bonuMalus;
    public static UnityEvent timeOver = new UnityEvent();
    [SerializeField] private TimerUI timerUI;

    private void OnEnable()
    {
        SpawnerManager.onEnemySlay.AddListener(AnswerToEnemySlay);
        SlashController.onObstacleOrWrongEnemyHit.AddListener(AnswerToObstacleOrWrongEnemySlay);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalParametersManager.instance.isGameOn)
        {
            timeLeft -= Time.deltaTime;
            timerUI.DecreaseTimer(timeLeft);
            if(timeLeft <= 0)
            {
                timeOver.Invoke();
            }
        }
        
    }

    private void AnswerToEnemySlay()
    {
        timeLeft += bonuMalus;
        timerUI.BonusMalus(bonuMalus);
    }

    private void AnswerToObstacleOrWrongEnemySlay()
    {
        timeLeft -= bonuMalus;
        timerUI.BonusMalus(-bonuMalus);
    }
}
