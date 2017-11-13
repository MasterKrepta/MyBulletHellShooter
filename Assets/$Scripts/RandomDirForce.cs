using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirForce : MonoBehaviour {

    Rigidbody2D rb;
    float randomValue;
    public float magnatude = 1.0f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        randomValue = Random.value * 1024.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(new Vector2(Random.Range(-1.0f, 1.0f) * magnatude, Random.Range(-1.0f, 1.0f) * magnatude));
    }
}
