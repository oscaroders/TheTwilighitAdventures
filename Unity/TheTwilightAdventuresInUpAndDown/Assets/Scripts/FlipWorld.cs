using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWorld : MonoBehaviour {

    FlipableObject[] childrenTransform;
    float timer;
	// Use this for initialization
	void Start () {
        childrenTransform = GetComponentsInChildren<FlipableObject>();	
	}

    //Blocken behöver ha Center som pivo punkt
    //Borde ha någon koll som kontrollerar att det är C
    void FlipTheWorld()
    {
        Debug.Log("Number of Children" + childrenTransform.Length);
        Vector3 positionRelativeToObject;
        for (int i = 0; i < childrenTransform.Length; i++)
        {
            if (childrenTransform[i].isFlippable)
            {
                positionRelativeToObject = GetRelativePosition(transform, childrenTransform[i].transform.position);
                Debug.Log("Position Vector(X,Y,Z): " + positionRelativeToObject.ToString());


                //Inverts the rotation of the object
                childrenTransform[i].transform.rotation = new Quaternion(childrenTransform[i].transform.rotation.x, childrenTransform[i].transform.rotation.y, -childrenTransform[i].transform.rotation.z, childrenTransform[i].transform.rotation.w);


                if (childrenTransform[i].startPosition == childrenTransform[i].transform.position)
                {
                    childrenTransform[i].SetPosition(new Vector3(childrenTransform[i].startPosition.x, -positionRelativeToObject.y + transform.position.y, childrenTransform[i].startPosition.z));
                }
                else
                {
                    childrenTransform[i].SetPosition(childrenTransform[i].startPosition);
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

        return relativePosition;
    }



    // Update is called once per frame
    void Update () {
		if(Input.GetButton("Cancel") && timer > 1)
        {
            FlipTheWorld();
            timer = 0;
            Debug.Log("Flip World");
        }
        timer += Time.deltaTime;
	}
}
