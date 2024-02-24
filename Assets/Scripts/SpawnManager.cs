using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnLocation;
    [SerializeField] int enemyType = 0;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;

    private void Start()
    {

        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    private void SpawnEnemies()
    {
            GameObject enemy = PoolManager.Instance.GetPooledObjects(enemyType, spawnLocation.position, spawnLocation.rotation);
            if(enemy != null)
            {
                enemy.SetActive(true);
            }else
            {
                Debug.LogError("Pool demasiado pequeno");
            }
    }
}
