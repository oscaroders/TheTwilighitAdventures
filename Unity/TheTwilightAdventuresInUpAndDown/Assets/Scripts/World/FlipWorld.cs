using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D;

public class FlipWorld : MonoBehaviour {

    FlipableObject[] childrenTransform;
    float timer;
    PlayerInput pi;
    float slowdownFactor = 0.1f;
    float slowdownLength = 1f;
    float speedUpLength = 0.5f;
    public static int numberOfCorutines;
    private AudioSource boom;

    private List<SpriteShapeRenderer> childRenderers = new List<SpriteShapeRenderer>();

    private bool fading;
    void Start()
    {
        boom = GameObject.Find("FlipWorldSound").GetComponent<AudioSource>();
        pi = FindObjectOfType<PlayerInput>();
        childrenTransform = GetComponentsInChildren<FlipableObject>();
        StartCoroutine(UpdateFlipPosition());
        SpriteShapeRenderer knase23;
        foreach (FlipableObject childFlipObject in childrenTransform)
        {
            if(childFlipObject.isFlippable)
            {
                knase23 = childFlipObject.GetComponent<SpriteShapeRenderer>();
                if (knase23 != null)
                {
                    childRenderers.Add(knase23);
                    knase23 = null;
                }
            }
        }
    }
    public void FlipTheWorld(bool state)
    {
        
        if (state && numberOfCorutines < 1)
        {
            StopAllCoroutines();
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
            boom.Play();
            numberOfCorutines++;
            Time.timeScale = slowdownFactor;
            StartCoroutine(FlipObjectFadeOut());
            yield return new WaitForSecondsRealtime(1f);
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
            StartCoroutine(FlipObjectFadeIn());
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

    IEnumerator FlipObjectFadeOut()
    {
        fading = true;
        while (childRenderers[0].material.color.a > 0)
        {
            foreach (SpriteShapeRenderer childSprite in childRenderers)
            {
                childSprite.material.color = new Color(childSprite.material.color.r, childSprite.material.color.g, childSprite.material.color.b, childSprite.material.color.a - (1f / speedUpLength) * Time.unscaledDeltaTime);
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }
        fading = false;
        yield return null;
    }
    IEnumerator FlipObjectFadeIn()
    {
        StopCoroutine(FlipObjectFadeOut());
        while(fading)
        {
            yield return new WaitForEndOfFrame();
        }
        while (childRenderers[0].material.color.a < 1)
        {
            foreach (SpriteShapeRenderer childSprite in childRenderers)
            {
                childSprite.material.color = new Color(childSprite.material.color.r, childSprite.material.color.g, childSprite.material.color.b, childSprite.material.color.a + (1f / speedUpLength) * Time.unscaledDeltaTime * 4);
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return null;
    }
}
