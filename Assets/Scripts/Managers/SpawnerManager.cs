using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemyBehaviorController[] enemies;
    [SerializeField] private EnemySpawner[] spawners;
    private GlobalParametersManager.Difficulty difficulty;
    private int enemyQtyOnField;
    public int numberOfEnemiesOnFieldEasyDifficulty;
    public int numberOfEnemiesOnFieldMediumDifficulty;
    public int numberOfEnemiesOnFieldHardDifficulty;
    private int numberOfEnemiesToHave;

    private void OnEnable()
    {
        difficulty = GlobalParametersManager.instance.difficulty;
        switch(difficulty)
        {
            case GlobalParametersManager.Difficulty.Easy:
                numberOfEnemiesToHave = numberOfEnemiesOnFieldEasyDifficulty;
                break;
            case GlobalParametersManager.Difficulty.Medium:
                numberOfEnemiesToHave = numberOfEnemiesOnFieldMediumDifficulty;
                break;
            case GlobalParametersManager.Difficulty.Hard:
                numberOfEnemiesToHave = numberOfEnemiesOnFieldHardDifficulty;
                break;
        }
        GlobalParametersManager.instance.isGameOn = true;
        StartCoroutine(SpawnEnemyCoroutine());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while(GlobalParametersManager.instance.isGameOn)
        {
            if (enemyQtyOnField < numberOfEnemiesToHave)
            {
                int randomSpawnerId = Random.Range(0, spawners.Length);
                EnemySpawner randomPickedSpawner = spawners[randomSpawnerId];

                int randomEnemyId = Random.Range(0, enemies.Length);
                EnemyBehaviorController randomPickedEnemy = enemies[randomEnemyId];

                randomPickedSpawner.SpawnEnemy(randomPickedEnemy);

                enemyQtyOnField++;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
