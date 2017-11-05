using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(MoveForward))]
public class RandomSpeed : MonoBehaviour {

    int randomSpeed;
    MoveForward moveScript;
	
    // Use this for initialization
	void Awake () {
        
        moveScript = GetComponent<MoveForward>();
        GetRandomSpeed();
        moveScript.speed = randomSpeed;
	}

    void GetRandomSpeed() {
        randomSpeed = Random.Range(1, 3);
    }
	

}
