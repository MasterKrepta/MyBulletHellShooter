using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JHook : MonoBehaviour {

    public Vector3 turnArroundThreshold;
    public Vector3 hookPos;

    public float rotSpeed;
    Vector3 angle = new Vector3(0, 0, 180);

    
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= turnArroundThreshold.y) {
           TurnArround(); // this should happen smoothly over time
          
        }
	}

    void TurnArround() {
        transform.rotation = Quaternion.Euler(-angle); //TODO this is not perfect
        transform.position = Vector3.MoveTowards(transform.position, hookPos, rotSpeed);
    }
}
