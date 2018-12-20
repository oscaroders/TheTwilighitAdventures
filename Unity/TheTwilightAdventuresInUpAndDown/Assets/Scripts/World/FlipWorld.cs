using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWorld : MonoBehaviour {

    FlipableObject[] childrenTransform;
    float timer;
    PlayerInput pi;
    float slowdownFactor = 0.5f;
    float slowdownLength = 1f;
    float speedUpLength = 0.5f;
    public static int numberOfCorutines;

    void Start()
    {
        pi = FindObjectOfType<PlayerInput>();
        childrenTransform = GetComponentsInChildren<FlipableObject>();
        StartCoroutine(UpdateFlipPosition());
    }
    public void FlipTheWorld(bool state)
    {
        if (state)
        {
            StartCoroutine(SlowDownEffect());
        }

    }
    public static Vector3 GetRelativePosition(Transform origin, Vector3 position)
    {
        Vector3 distance = position - origin.position;
        Vector3 relativePosition = Vector3.zero;
        relativePosition.x = Vector3.Dot(distance, origin.right.normalized);
        relativePosition.y = Vector3.Dot(distance, origin.up.normalized);
        relativePosition.z = Vector3.Dot(distance, origin.forward.normalized);

        relativePosition.y = -relativePosition.y + origin.position.y;
        return relativePosition;
    }

    IEnumerator UpdateFlipPosition()
    {

        while (gameObject) {

            childrenTransform = GetComponentsInChildren<FlipableObject>();
            for (int i = 0; i < childrenTransform.Length; i++)
            {
                if (childrenTransform[i].isFlippable)
                {
                    // Save its position
                    childrenTransform[i].SetStartPosition(childrenTransform[i].transform.position, childrenTransform[i].transform.rotation);

                    // Calculate and save its flipt position
                    childrenTransform[i].SetEndPosition(GetRelativePosition(transform, childrenTransform[i].startPosition), Quaternion.Inverse(childrenTransform[i].transform.rotation));

                }
            }

            yield return new WaitForEndOfFrame();
        }

        
    }

    IEnumerator SlowDownEffect()
    {
        if(numberOfCorutines < 1)
        {
            numberOfCorutines++;
            while (Time.timeScale > slowdownFactor)
            {
                Time.timeScale -= (1f / slowdownLength) * Time.unscaledDeltaTime;
                Time.fixedDeltaTime = Time.timeScale * .02f;
                yield return new WaitForEndOfFrame();
            }
            if (pi.canFlip)
            {
                for (int i = 0; i < childrenTransform.Length; i++)
                {
                    if (childrenTransform[i].isFlippable)
                    {

                        if (childrenTransform[i].transform.position == childrenTransform[i].startPosition)
                        {
                            childrenTransform[i].GoToEnd();
                        }
                        else
                        {
                            childrenTransform[i].GoToStart();
                        }
                    }
                }
            }
            else
            {
                //Maybe Play a sound when it does not work
            }
            pi.CannotFlipShake();


            while (Time.timeScale < slowdownFactor)
            {
                Time.timeScale += (1f / speedUpLength) * Time.unscaledDeltaTime;
                Time.fixedDeltaTime = Time.timeScale * .02f;
                yield return new WaitForEndOfFrame();
            }
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * .02f;

            numberOfCorutines--;
            
        }
        yield return null;

    }

}
