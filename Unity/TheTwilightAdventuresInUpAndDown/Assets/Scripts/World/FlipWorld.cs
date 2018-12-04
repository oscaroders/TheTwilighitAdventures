using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWorld : MonoBehaviour {

    FlipableObject[] childrenTransform;
    float timer;
    void Start()
    {
        Quaternion rotation;
        childrenTransform = GetComponentsInChildren<FlipableObject>();
        for (int i = 0; i < childrenTransform.Length; i++)
        {
            if (childrenTransform[i].isFlippable)
            {
                // Save its position
                childrenTransform[i].SetStartPosition(childrenTransform[i].transform.position, childrenTransform[i].transform.rotation);

                // Calculate and save its flipt position
                rotation = childrenTransform[i].transform.rotation;
                rotation.y = -rotation.y;
                childrenTransform[i].SetEndPosition(GetRelativePosition(transform, childrenTransform[i].startPosition), rotation);
            }
        }
    }
    void FlipTheWorld()
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



    // Update is called once per frame
    void Update () {
		if(Input.GetButton("Cancel") && timer > 0.1f)
        {
            FlipTheWorld();
            timer = 0;
            Debug.Log("Flip World");
        }
        timer += Time.deltaTime;
	}
}
