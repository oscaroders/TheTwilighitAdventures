using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private CameraFollowTarget followTarget;
    private Vector3 cameraPosition;

    float shakeAmount = 0;

    private void Start() {

        followTarget = GetComponent<CameraFollowTarget>();
        
    }

    public void Shake(float amount, float length) {
        
        shakeAmount = amount;
        cameraPosition = transform.position;
        followTarget.enabled = false;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }


    void DoShake() {

        if (shakeAmount > 0) {
           

            Vector3 camPos = transform.position;

            float shakeAmtX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmtY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += shakeAmtX;
            camPos.y += shakeAmtY;
            Debug.Log("x: " + shakeAmtX);
            transform.position = camPos;
        }
    }

    void StopShake() {
        CancelInvoke("DoShake");
        transform.localPosition = cameraPosition;
        
        followTarget.enabled = true;
    }
}
