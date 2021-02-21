using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabs;

    public void Spawn()
    {
        var rand = UnityEngine.Random.Range(0, attackerPrefabs.Length);
        var attacker = Instantiate(attackerPrefabs[rand], transform.position, Quaternion.identity);
        attacker.transform.parent = transform;

        FindObjectOfType<LevelController>().AttackerSpawned();
    }
}
