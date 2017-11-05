using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour {

    public GameObject lootPrefab;

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
            for (int i = 0; i <= qtyToSpawn; i++) {
                PoolingManager.InstantiatePooled(lootPrefab, transform.position, Quaternion.identity);
            }
        }
        
    }
}
