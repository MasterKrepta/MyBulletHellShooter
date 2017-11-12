using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Tentacle : MonoBehaviour
{

    internal Rigidbody2D rb;
    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.isKinematic = true;
        int childCount = this.transform.childCount;

        for (int i = 0; i < childCount; i++) {
            Transform t = this.transform.GetChild(i);

            if (t.gameObject.GetComponent<HingeJoint2D>() == null) {
                t.gameObject.AddComponent<HingeJoint2D>();
            }
                
            HingeJoint2D hinge = t.gameObject.GetComponent<HingeJoint2D>();

            hinge.connectedBody = i == 0 ? this.rb : this.transform.GetChild(i - 1).GetComponent<Rigidbody2D>();

            hinge.useMotor = true;
            hinge.enableCollision = true;
        }
    }
}
	

