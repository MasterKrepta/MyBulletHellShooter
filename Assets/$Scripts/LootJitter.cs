using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootJitter : MonoBehaviour {
    public Vector3 angle = new Vector3(0, 0, 10);
    // Use this for initialization
    void Start () {
        
        transform.rotation = Quaternion.EulerAngles(-angle); //TODO this is not perfect
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
