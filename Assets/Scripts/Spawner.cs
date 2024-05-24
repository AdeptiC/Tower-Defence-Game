using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Spawner for mobs
public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyprefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 5;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private float difficultyScalingFactor = 0.5f;

    [Header("Test")]
    [SerializeField] private int currentWave = 1;
    [SerializeField] private float timeSinceLastSpawn;
    [SerializeField] private int enemiesAlive;
    [SerializeField] private int enemiesLeftToSpawn;
    [SerializeField] private bool isSpawning = false;

    private int curEnemyTypeMax = 1;

    [Header("Events")]
    public static UnityEvent onEnemyDestroyed = new UnityEvent();

    private void Awake()
    {
        onEnemyDestroyed.AddListener(EnemyDestroyed);
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        enemiesPerSecond = 0.5f + 0.1f * currentWave;
        if (currentWave % 3 == 0 && curEnemyTypeMax <= 3)
            curEnemyTypeMax += 1;

        if (currentWave == 6)
            SceneManager.LoadScene("Victory");

        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        // Choose a random index within the range of enemyprefabs array
        int randomIndex = Random.Range(0, curEnemyTypeMax);
        if (currentWave % 5 == 0 && enemiesLeftToSpawn <= currentWave / 5)
        {
            randomIndex = 4;
        }
        else if (currentWave > 10 && Random.Range(0, 30 - currentWave) == 0)
        {
            randomIndex = 4;
        }

        // Get the randomly chosen prefab
        GameObject prefabToSpawn = enemyprefabs[randomIndex];

        // Spawn the enemy prefab
        Instantiate(prefabToSpawn, LevelManager.main.StartPoint.position, Quaternion.identity);
    }


    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}