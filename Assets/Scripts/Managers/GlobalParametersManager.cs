using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalParametersManager : MonoBehaviour
{
    public static GlobalParametersManager instance;
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public Difficulty difficulty;
    public bool isGameOn;
    public Transform playerPos;
    private int finalScore;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameOverUI gameOverUI;

    private void Awake()
    {
        if (instance != null && instance == this)
        {
            Destroy(gameObject);
        }
        switch(MainMenuManager.Instance.chosenDifficulty)
        {
            case 0:
                difficulty = Difficulty.Easy;
                break;
            case 1:
                difficulty = Difficulty.Medium;
                break;
            case 2:
                difficulty = Difficulty.Hard;
                break;
        }
        instance = this;
    }

    private void OnEnable()
    {
        TimerManager.timeOver.AddListener(GameOverSequence);
    }

    private void GameOverSequence()
    {
        isGameOn = false;
        gameOverUI.gameObject.SetActive(true);
        finalScore = scoreManager.score;
        gameOverUI.DisplayScoreText(finalScore);
    }

    public void ReplayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
}
