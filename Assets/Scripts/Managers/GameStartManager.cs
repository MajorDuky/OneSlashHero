using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStartManager : MonoBehaviour
{
    public static UnityEvent onGameStarted = new UnityEvent();
    [SerializeField] private float countdownTimer;
    [SerializeField] private GameStartUI gameStartUI;

    // Start is called before the first frame update
    void Start()
    {
        gameStartUI.GameStartUISequence(countdownTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalParametersManager.instance.isGameOn)
        {
            onGameStarted.Invoke();
            gameStartUI.gameObject.SetActive(false);
        }
    }
}
