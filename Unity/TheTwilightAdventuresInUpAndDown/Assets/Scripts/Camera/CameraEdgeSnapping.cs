using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdgeSnapping : MonoBehaviour {

    public Camera camera;

    public Transform leftBound;
    public Transform rightBound;
    public Transform topBound;
    public Transform bottomBound;


    public bool isUp;
    private void Start()
    {
        if(leftBound == null || rightBound == null || topBound == null || bottomBound == null)
        {
            PlayerInput playerInput = GetComponentInParent<PlayerInput>();
            Room[] rooms = FindObjectsOfType<Room>();
            Room currentRoom = null;
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].roomId == playerInput.currentRoomId)
                {
                    currentRoom = rooms[i];
                    break;
                }
            }
            if (currentRoom != null)
            {
                leftBound = currentRoom.leftPosition;
                rightBound = currentRoom.rightPosition;
                if (transform.parent.name == "Eve")
                {
                    topBound = currentRoom.topPosition;
                    bottomBound = currentRoom.middlePosition;
                }
                else
                {
                    topBound = currentRoom.middlePosition;
                    bottomBound = currentRoom.bottomPosition;
                }
            }
        }
        
        

    }
    // Update is called once per frame
    // Update is called after all update functions are done.
    void LateUpdate () {
		//Save our position in a tmp variable that we can modify like we want
		Vector3 tmpPosition = transform.position;

		    //Calculate the min and max position with boundry objects and camera size + aspect
		float minX = leftBound.position.x + camera.orthographicSize * camera.aspect;
		float maxX = rightBound.position.x - camera.orthographicSize * camera.aspect;
		    //Clamp the position, so it can't go outside min or max interval
		tmpPosition.x = Mathf.Clamp(tmpPosition.x, minX, maxX);

		//Do the same for Y direction.
		float maxY = topBound.position.y - camera.orthographicSize;
		float minY = bottomBound.position.y + camera.orthographicSize;
		tmpPosition.y = Mathf.Clamp(tmpPosition.y, minY, maxY);

		//Set our position to the clamped position.
		transform.position = tmpPosition;
	}

    public void ChangeBounds(Transform top, Transform bottom, Transform left, Transform right)
    {
        topBound = top;
        bottomBound = bottom;
        leftBound = left;
        rightBound = right;

    }

    public float CalculateMinX(float xPos)
    {
        return xPos + camera.orthographicSize * camera.aspect;
    }
}
