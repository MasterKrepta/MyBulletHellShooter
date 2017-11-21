using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MoveForward))]
public class FlightPath : MonoBehaviour {

    public Transform[] checkpoints;
    public Transform nextCheckpoint;
    MoveForward moveForward;

    int index = 0;

    public float speed = 2.0f;
    


    float dist = 0;
    float minDist = .5f;
    bool lastCheckpoint = false;
    
    // Use this for initialization
    void Start () {
        moveForward = GetComponent<MoveForward>();
		if(checkpoints == null) {
            Debug.LogWarning("No Checkpoints are set for gameobject " + this.name);
        } else {
            nextCheckpoint = checkpoints[0];
        }
	}
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(this.transform.position, nextCheckpoint.position);
        float step = speed * Time.deltaTime;

        if(dist > minDist && !lastCheckpoint) {
            //transform.position += (transform.up * directionMod) * speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nextCheckpoint.position, step);
            Vector3 dir = nextCheckpoint.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 270, Vector3.forward);
        }
        else {
            GetNextCheckpoint();
        }
        
    }

    void ChangeDirection() {
        moveForward.directionMod *= -1;
    }

    void GetNextCheckpoint() {
        
        if (index < checkpoints.Length) {
            nextCheckpoint = checkpoints[index];
            index++;
        }
        else {
            moveForward.enabled = true;
            //moveForward.directionMod = 1;
            lastCheckpoint = true;
            //Debug.Log("max checkpoint");
        }
            
    }
}
