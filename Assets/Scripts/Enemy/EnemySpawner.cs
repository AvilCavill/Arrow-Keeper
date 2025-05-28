using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject prefab;
        public Transform spawnPoint;
        public int unlockAtRound; // Ronda en la que empieza a aparecer
    }

    public EnemyType[] enemyTypes;

    public Transform tower;
    public float spawnDelay = 1f;

    public int initialEnemiesPerRound = 3;
    private int currentRound = 1;

    void Start()
    {
        StartCoroutine(StartRounds());
    }

    IEnumerator StartRounds()
    {
        while (true)
        {
            int enemiesToSpawn = initialEnemiesPerRound + (currentRound - 1);
            Debug.Log(">> ROUND " + currentRound + " — Enemies: " + enemiesToSpawn);
            yield return StartCoroutine(SpawnWave(enemiesToSpawn));
            currentRound++;
            yield return new WaitForSeconds(5f); // Tiempo entre rondas
        }
    }

    IEnumerator SpawnWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Filtra los enemigos que pueden spawnear esta ronda
            var availableEnemies = new System.Collections.Generic.List<EnemyType>();
            foreach (var enemy in enemyTypes)
            {
                if (currentRound >= enemy.unlockAtRound)
                    availableEnemies.Add(enemy);
            }

            // Selecciona un tipo aleatorio entre los disponibles
            EnemyType chosen = availableEnemies[Random.Range(0, availableEnemies.Count)];

            GameObject instance = Instantiate(chosen.prefab, chosen.spawnPoint.position, Quaternion.identity);
            EnemyIA enemyScript = instance.GetComponent<EnemyIA>();
            if (enemyScript != null)
                enemyScript.target = tower;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}