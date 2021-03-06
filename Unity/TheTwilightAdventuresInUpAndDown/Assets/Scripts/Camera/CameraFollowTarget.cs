﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour {

    [SerializeField] internal Vector2 focusAreaSize;
    public BoxCollider2D collider;

    public float verticalOffset;
    public float lookAheadDstX;
    public float lookAheadDstUp;
    public float lookAheadDstDown;
    public float lookSmoothTimeX;
    public float lookSmoothTimeY;
    //public float verticalSmoothTime;
    public float cameraYPositioning;

    FocusArea focusArea;
    bool isUp;

    float currentLookAheadX;
    float targetLookAheadX;
    float lookAheadDirX;
    float smoothLookVelocityX;

    float currentLookAheadY;
    float targetLookAheadY;
    float lookAheadDirY;
    float smoothLookVelocityY;

    float smoothVelocityY;

    bool lookAheadStopped;

    private void Start() {
        isUp = GetComponent<CameraEdgeSnapping>().isUp;
        focusArea = new FocusArea(collider.bounds, focusAreaSize, isUp);
    }

    private void LateUpdate() {
        focusArea.Update(collider.bounds);

        Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;

        if(focusArea.velocity.x != 0) {
            lookAheadDirX = Mathf.Sign(focusArea.velocity.x);
            if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) == Mathf.Sign(focusArea.velocity.x) && Input.GetAxisRaw("Horizontal") != 0) {
                lookAheadStopped = false;
                targetLookAheadX = lookAheadDirX * lookAheadDstX;
            } else {
                if (!lookAheadStopped) {
                    lookAheadStopped = true;
                    targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX) / 4f;
                }
            }
        }

        currentLookAheadX = Mathf.SmoothDamp(currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

        // -------------------------------------------
        if(focusArea.velocity.y != 0) {
            if (focusArea.velocity.y > 0) {
                lookAheadDirY = 1;
                targetLookAheadY = lookAheadDirY * lookAheadDstUp;
            } else if (focusArea.velocity.y < 0) {
                lookAheadDirY = -1;
                targetLookAheadY = lookAheadDirY * lookAheadDstDown;
            }
        }

        currentLookAheadY = Mathf.SmoothDamp(currentLookAheadY, targetLookAheadY, ref smoothLookVelocityY, lookSmoothTimeY);

        //focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
        //focusPosition += Vector2.up * currentLookAheadY;


        //focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
        //focusPosition += Vector2.right * currentLookAheadX;
        focusPosition += new Vector2(currentLookAheadX, currentLookAheadY);
        transform.position = (Vector3)focusPosition + Vector3.forward * -10;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(focusArea.centre, focusAreaSize);
    }

    struct FocusArea {
        public Vector2 centre;
        public Vector2 velocity;
        float left, right;
        float top, bottom;

        public FocusArea(Bounds targetBounds, Vector2 size, bool isUp) {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            if (isUp) {
                bottom = targetBounds.min.y;
                top = targetBounds.min.y + size.y;
            } else if(!isUp) {
                bottom = targetBounds.max.y - size.y;
                top = targetBounds.max.y;
            } else {
                bottom = targetBounds.min.y;
                top = targetBounds.min.y + size.y;
            }

            velocity = Vector2.zero;
            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
        }

        public void Update(Bounds targetBounds) {
            float shiftX = 0;

            if (targetBounds.min.x < left) {
                shiftX = targetBounds.min.x - left;

            } else if (targetBounds.max.x > right) {
                shiftX = targetBounds.max.x - right;

            }

            left += shiftX;
            right += shiftX;

            float shiftY = 0;

            if (targetBounds.min.y < bottom) {
                shiftY = targetBounds.min.y - bottom;

            } else if (targetBounds.max.y > top) {
                shiftY = targetBounds.max.y - top;

            }

            top += shiftY;
            bottom += shiftY;

            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = new Vector2(shiftX, shiftY);
        }
    }

    //public Transform target; // player

    //public Vector3 offset;

    //private void Start() {
    //    offset = transform.position + target.position;
    //}

    //// Update is called once per frame
    //void LateUpdate() {

    //    Vector3 cameraMovement = target.position - transform.position;
    //    //Take 5% of this vector
    //    cameraMovement.x = cameraMovement.x * 0.05f;
    //    cameraMovement.y *= 0.05f;
    //    cameraMovement.z = 0;

    //    //move that 5% closer
    //    transform.Translate(cameraMovement);
    //}
}
