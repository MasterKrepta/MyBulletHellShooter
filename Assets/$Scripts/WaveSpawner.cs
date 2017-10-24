using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject[] enemies;
    public float spawnRate = 1.5f;
    
	// Use this for initialization
	void Start () {
        StartCoroutine("Spawn", spawnRate);
	}
	
	// Update is called once per frame
	IEnumerator Spawn () {
        for (int i = 0; i < enemies.Length; i++) {
            Instantiate(enemies[i], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        Debug.Log("we spawned a wave");
        
	}
}
