using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public GameObject bombPrefab;
    public Transform[] spawnPoints;
    
    [Range(0, 1)] public float bombChance = 0.1f;

    public float spawnInterval = 1f;
    public float intervalDecrease = 0.01f;
    public float minInterval = 0.35f;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            if (Random.value < bombChance)
            {
                Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("Bomb spawned!");
            }
            else
            {
                Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("Fruit spawned!");
            }
            if(spawnInterval > minInterval)
            {
                spawnInterval -= intervalDecrease;
            }
            else
            {
                spawnInterval = minInterval;
            }
        }
    }
    ~Spawner()
    {
        Debug.Log("Spawner destructor");
    }

}