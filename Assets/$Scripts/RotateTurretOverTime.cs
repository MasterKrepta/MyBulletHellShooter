using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurretOverTime : MonoBehaviour {

    [SerializeField]
    private float maxRotation;
    [SerializeField]
    private float rotSpeed = 10;

	void Start () {
        StartCoroutine("RotateForward");
    }

    IEnumerator RotateForward() {
        float t = 0;
        while (t < rotSpeed *.5f) {
            transform.RotateAround(transform.position, transform.forward, 
                                    Time.deltaTime / (rotSpeed * .5f) * maxRotation);
            t += Time.deltaTime;
            yield return null;
        }
        StartCoroutine("RotateBack");
    }
    IEnumerator RotateBack() {
        float t = 0;
        while (t < rotSpeed * .5f) {
            transform.RotateAround(transform.position, transform.forward,
                                    -Time.deltaTime / (rotSpeed * .5f) * maxRotation);
            t += Time.deltaTime;
            yield return null;
        }
        StartCoroutine("RotateForward");
    }
}
