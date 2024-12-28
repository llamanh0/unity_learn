using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRangeMax = 9.0f;
    [SerializeField] private float spawnRangeMin = 3.0f;

    void Start()
    {
        Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
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
