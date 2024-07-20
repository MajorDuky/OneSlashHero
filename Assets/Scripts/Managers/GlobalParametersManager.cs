using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        if (instance != null && instance == this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
