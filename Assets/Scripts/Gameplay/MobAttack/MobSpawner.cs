using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobSpapwner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WorldTime worldTime;
    [SerializeField] private GameObject[] enemyPrefabs;


    [Header("Attributes")]
    [SerializeField] private int enemyNumber = 8;
    [SerializeField] private float enemyPerSecond = 1f;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float difficultyScallingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;


    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void OnEnable()
    {
        worldTime.StartEnemyWave += StartWave;
        worldTime.StopEnemyWave += EndWave;

    }

    private void OnDisable()
    {
        worldTime.StartEnemyWave -= StartWave;
        worldTime.StopEnemyWave -= EndWave;

    }

    void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemyPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesAlive++;
            enemiesLeftToSpawn--;
            timeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private void StartWave()
    {
        //yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(enemyNumber * Mathf.Pow(currentWave, difficultyScallingFactor));
    }
}
