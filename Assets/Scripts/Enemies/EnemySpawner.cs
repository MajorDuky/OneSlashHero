using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void SpawnEnemy(EnemyBehaviorController enemy)
    {
        Instantiate(enemy, transform);
    }
}
