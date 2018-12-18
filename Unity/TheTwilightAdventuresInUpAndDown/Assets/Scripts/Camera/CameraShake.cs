using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Camera cam;

    float shakeAmount = 0;

    private void Awake() {

        cam = GetComponent<Camera>();

        
    }

    public void Shake(float amt, float length) {
        
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }


    void DoShake() {

        if (shakeAmount > 0) {
           

            Vector3 camPos = cam.transform.position;

            float shakeAmtX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmtY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += 5;
            camPos.y += shakeAmtY;
            Debug.Log("x: " + shakeAmtX);
            cam.transform.position = camPos;
        }
    }

    void StopShake() {
        CancelInvoke("DoShake");
        cam.transform.localPosition = Vector3.zero;
    }
}
