using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawnerController : MonoBehaviour
{
    AttackerSpawner[] allAttackerSpawners;
    GameTimer gameTimer;
    [SerializeField] float maxTimeBetweenSpawn = 10f;
    [SerializeField] float minTimeBetweenSpawn = 0.5f;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] bool spawn = true;
    Coroutine spawnRepeatedly;


    // Start is called before the first frame update
    void Start()
    {
        allAttackerSpawners = FindObjectsOfType<AttackerSpawner>();
        gameTimer = FindObjectOfType<GameTimer>();
        timeBetweenSpawn = maxTimeBetweenSpawn;

        spawnRepeatedly = StartCoroutine(SpawnRepeatedly());
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawn = Mathf.Lerp(minTimeBetweenSpawn, maxTimeBetweenSpawn, 1 - gameTimer.GetProgress());
    }

    IEnumerator SpawnRepeatedly()
    {
        while (spawn)
        {
            yield return StartCoroutine(SpawnRandomly());
        }
    }

    IEnumerator SpawnRandomly()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        allAttackerSpawners[Random.Range(0, allAttackerSpawners.Length)].Spawn();
    }

    public void StopSpawning()
    {
        spawn = false;
        StopCoroutine(spawnRepeatedly);
    }
}
