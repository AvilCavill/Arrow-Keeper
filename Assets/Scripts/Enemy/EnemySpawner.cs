using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance; 
    [System.Serializable]
    public class EnemyType
    {
        public GameObject prefab;
        public Transform spawnPoint;
        public int unlockAtRound; // Ronda en la que aparece (ej: 1, 5, 10)
    }

    public EnemyType[] enemyTypes;
    public Transform tower;
    public float spawnDelay = 1f;

    // Configuración de rondas
    public int initialEnemies = 4;
    public int enemiesPerRoundIncrement = 1;
    public int maxRounds = 10;
    private int currentRound = 1;
    private int enemiesRemaining = 0;

    void Start()
    {
        StartCoroutine(StartRounds());
    }

    IEnumerator StartRounds()
    {
        while (currentRound <= maxRounds)
        {
            GameManager.GameManager.Instance.SetCurrentRound(currentRound);
            Debug.Log($"RONDA {currentRound}/{maxRounds}");
            yield return StartCoroutine(SpawnWave());
            currentRound++;
            yield return new WaitForSeconds(5f); // Tiempo entre rondas
        }
        GameManager.GameManager.Instance.YouWin();
        Debug.Log("¡Juego completado!");
    }

    IEnumerator SpawnWave()
    {
        
        // Calcular enemigos por tipo
        int basicCount = GetEnemyCountForType(1);    // Básico (ronda 1+)
        int flyingCount = GetEnemyCountForType(5);   // Volador (ronda 5+)
        int giantCount = GetEnemyCountForType(10);   // Gigante (ronda 10+)

        // Spawnear enemigos
        yield return StartCoroutine(SpawnEnemyType("EnemyBasic", basicCount));
        if (currentRound >= 5) yield return StartCoroutine(SpawnEnemyType("EnemyFlying", flyingCount));
        if (currentRound >= 10) yield return StartCoroutine(SpawnEnemyType("EnemyGiant", giantCount));
    }

    int GetEnemyCountForType(int unlockRound)
    {
        if (currentRound < unlockRound) return 0;
        
        // Fórmula: 5 iniciales + 2 por cada ronda después del unlock
        return initialEnemies + (currentRound - unlockRound) * enemiesPerRoundIncrement;
    }

    IEnumerator SpawnEnemyType(string enemyTag, int count)
    {
        for (int i = 0; i < count; i++)
        {
            EnemyType type = System.Array.Find(enemyTypes, e => e.prefab.tag == enemyTag);
            if (type != null)
            {
                GameObject enemy = Instantiate(type.prefab, type.spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<EnemyIA>().target = tower;
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}