using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float speed = 1.0f;
    public Transform model;
    public float tilt = 1.0f;

    // Update is called once per frame

    private void Start() {
        if(FindObjectOfType<GameManager>() == null) {
            Debug.LogWarning("No Game Manager Found... drag a prefab in");
        }
    }
    void Update () {
        
        Move();
	}

    private void Move() {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);


       model.rotation = Quaternion.Euler(0.0f, movement.x * -tilt, 0);

    }
}


