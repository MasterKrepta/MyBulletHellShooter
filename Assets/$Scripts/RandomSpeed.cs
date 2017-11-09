using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(MoveForward))]
public class RandomSpeed : MonoBehaviour {

    float randomSpeed;
    MoveForward moveScript;
	
    // Use this for initialization
	void Awake () {
        
        moveScript = GetComponent<MoveForward>();
        GetRandomSpeed();
        moveScript.speed = randomSpeed;
	}

    void GetRandomSpeed() {
        randomSpeed = Random.Range(.5f, 2f);
    }
	

}
