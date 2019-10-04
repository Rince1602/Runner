using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private Vector3 spawnValue;
    private int spawnCount = 20;

    private void Start()
    {
        SpawnCoins();    
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(spawnValue.x, spawnValue.x + 50), spawnValue.y, Random.Range(spawnValue.z, spawnValue.z + 50));
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(coin, spawnPosition, spawnRotation);
        }
    }
}
