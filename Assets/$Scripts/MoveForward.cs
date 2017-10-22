using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
    public float speed = 2.0f;
    [Range(-1, 1)][SerializeField][Tooltip("Negative will move down, positive move up")]
    private int directionMod = -1;
	// Use this for initialization
	void Start () {
		if(directionMod == 0) {
            directionMod = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {

        
        transform.position += (transform.up * directionMod) * speed * Time.deltaTime;
    }
}
