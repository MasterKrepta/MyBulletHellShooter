using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour {

    public GameObject lootPrefab;
    private float spawnRadius = .5f;

    [Range(3,10)]
    public int qtyToSpawn = 3;

    private void OnEnable() {
        GameManager.SpawnLoot += Spawn;
    }

    private void OnDisable() {
        GameManager.SpawnLoot -= Spawn;
    }

    void Spawn() {
        if (GetComponent<Health>().currentHealth != 0) { // cancel event if enemy is still alive
            return;
        }
        else {
            for (int i = 0; i < qtyToSpawn; i++) {
                //Debug.Log("spawned");
                Vector3 randPos = GenerateRandomPos();
                PoolingManager.InstantiatePooled(lootPrefab, randPos, transform.rotation);
                //Instantiate(lootPrefab, transform.position, transform.rotation);
            }
        }
        
    }

    Vector3 GenerateRandomPos() {
        Vector3 randPos = Vector3.zero;
        randPos = Random.insideUnitCircle * spawnRadius;
        randPos.y = transform.position.y;
        return randPos;
    }


}
