using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour {

    Transform myTransform;
    Vector3 angle = new Vector3(0, 0, 45);
	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(myTransform.position.y <= 0) {
            transform.rotation =  Quaternion.EulerAngles(-angle); //TODO this is not perfect
        }
	}
}
