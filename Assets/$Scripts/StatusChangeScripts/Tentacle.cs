using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Tentacle : MonoBehaviour
{

    internal Rigidbody2D rb;
    float distanceBetweenNodes = 0;
    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.isKinematic = true;
        int childCount = this.transform.childCount;

        for (int i = 0; i < childCount; i++) {
            Transform t = this.transform.GetChild(i);
            
            //Vector3 modPos = new Vector3(this.transform.position.x, distanceBetweenNodes, 0);
            
            //t.position = modPos;
            //distanceBetweenNodes -=  0.5f; 
            if (t.gameObject.GetComponent<HingeJoint2D>() == null) {
                t.gameObject.AddComponent<HingeJoint2D>();
            }
            HingeJoint2D hinge = t.gameObject.GetComponent<HingeJoint2D>();

            hinge.connectedBody = i == 0 ? this.rb : this.transform.GetChild(i - 1).GetComponent<Rigidbody2D>();
            
           // hinge.useMotor = true;
           hinge.enableCollision = false;
        }
    }
}
	

