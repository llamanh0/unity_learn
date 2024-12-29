using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private float spawnRangeMax = 9.0f;
    [SerializeField] private float spawnRangeMin = 3.0f;
    private int waveNumber = 1;
    private int enemyCount;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX;
        float spawnPosZ;

        // Control for Enemy start position.
        do { spawnPosX = Random.Range(-spawnRangeMax, spawnRangeMax);
        } while (spawnPosX < spawnRangeMin && spawnPosX > -spawnRangeMin);
        do{ spawnPosZ = Random.Range(-spawnRangeMax, spawnRangeMax);
        } while ((spawnPosZ < spawnRangeMin && spawnPosZ > -spawnRangeMin));
        
        return new Vector3(spawnPosX, .15f, spawnPosZ);
    }
}
