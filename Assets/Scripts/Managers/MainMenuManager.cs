using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    public int chosenDifficulty;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void EasyPlayPress()
    {
        chosenDifficulty = 0;
        SceneManager.LoadScene(1);
    }

    public void MediumPlayPress()
    {
        chosenDifficulty = 1;
        SceneManager.LoadScene(1);
    }

    public void HardPlayPress()
    {
        chosenDifficulty = 2;
        
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
