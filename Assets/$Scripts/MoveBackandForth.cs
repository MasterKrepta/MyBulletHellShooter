using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour {

    public float speed = 10f;
    public float frequency = 1f;
    public float amplitude = 1f;
    private float hOffset = 0f;
    float time = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        // remove offset
        transform.position -= hOffset * transform.right;

        // moves forward
        transform.position += transform.forward * speed * Time.deltaTime;

        // adjust with sign wave
        hOffset = Mathf.Sin(time * frequency) * amplitude;

        transform.position += hOffset * transform.right;
    }
}
