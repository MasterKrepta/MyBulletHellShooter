using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOverTime : MonoBehaviour {

    public float lifetime = .2f;
    float time;

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(true);
        time = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time<= 0) {
            MakeInvisible();
        }
	}
    private void OnDisable() {
        time = lifetime;
    }

    void MakeInvisible() {
        this.gameObject.SetActive(false);
    }
}
