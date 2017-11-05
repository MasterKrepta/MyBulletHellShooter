using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNearestTarget : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    public LayerMask enemyLayer;
    float radius = 10;

    Rigidbody2D rb;
    public float missleSpeed = 10f;
    float rotSpeed = 300f;
    float lockonTime = 1f;
    float time = 0;
    


    private void Start() {
        time = lockonTime;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() {
        // Debug.Log("Missle spawned");
        time = lockonTime;
        DetectTarget();
        
    }
    private void OnDisable() {
        //Debug.Log("Missle Deactivated");
        target = null;
    }

    // Update is called once per frame
    void FixedUpdate () {
        time -= Time.deltaTime;
        if (target != null) {
            MoveToTarget();
        }
        else {
            MoveForward();
        }
        if(time <= 0) {
            target = null;
        }

	}

    void DetectTarget() {
        
         Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        try { 
            target = hitColliders[0].gameObject;
        } catch {
            this.gameObject.SetActive(false);
            return;
        }
        
        float dist = Vector2.Distance(transform.position, hitColliders[0].transform.position);
        for (int i = 0; i < hitColliders.Length; i++) {
            
            float tempDist = Vector2.Distance(transform.position, hitColliders[i].transform.position);

            if (tempDist < dist) {
                target = hitColliders[i].gameObject;
            }
        }
        
    }

    void MoveToTarget() {
        if(target != null) {

            Vector2 dir = (Vector2)target.transform.position - rb.position;
            dir.Normalize();

            float rotAmount = Vector3.Cross(dir, transform.up).z;

            rb.angularVelocity = -rotAmount * rotSpeed;

            rb.velocity = transform.up * missleSpeed;
        }
       
    }
    void MoveForward() {
        // if we havent hit our target, move offscreen
        Debug.Log("No target");
        rb.velocity = transform.up * missleSpeed;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);    
    }


}
