using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour {

    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position + target.position;
    }

    // Update is called once per frame
    void LateUpdate () {

        Vector3 cameraMovement = target.position - transform.position;
        //Take 5% of this vector
        cameraMovement.x = cameraMovement.x * 0.05f;
        cameraMovement.y *= 0.05f;
        cameraMovement.z = 0;

        //move that 5% closer
        transform.Translate(cameraMovement);
    }
}
