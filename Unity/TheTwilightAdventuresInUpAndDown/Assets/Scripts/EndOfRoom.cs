using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfRoom : ActionObject
{
    [SerializeField] private bool isLevelEnd;
    [SerializeField] private string sceneName;

    private CameraEdgeSnapping upEdgeSnapping;
    private CameraEdgeSnapping downEdgeSnapping;

    private CameraFollowTarget upCameraFollow;
    private CameraFollowTarget downCameraFollow;

    private PlayerMovement eve;
    private PlayerMovement dodo;

    public Transform newBlockerTarget;


    public Transform[] blockers;

    public Room nextRoom;

    private bool rightBoundSet = false;
    float leftBoundPositionX;

    bool wasActivated;
    private PlayerInput playerInput;

    [Range(0f,20f)]public float panningSpeed = 1f;

    private void Start()
    {
        eve = GameObject.Find("Eve").GetComponent<PlayerMovement>();
        dodo = GameObject.Find("Dodo").GetComponent<PlayerMovement>();
        CameraEdgeSnapping[] allEdgeSnapping = FindObjectsOfType<CameraEdgeSnapping>();
        foreach (CameraEdgeSnapping item in allEdgeSnapping)
        {
            if(item.gameObject.name == "Up Camera")
            {
                upEdgeSnapping = item;
            }
            if (item.gameObject.name == "Down Camera")
            {
                downEdgeSnapping = item;
            }
        }
        if(nextRoom.leftPosition != null)
        {
            leftBoundPositionX = nextRoom.leftPosition.position.x;
        }
       

        upCameraFollow = upEdgeSnapping.gameObject.GetComponent<CameraFollowTarget>();
        downCameraFollow = downEdgeSnapping.gameObject.GetComponent<CameraFollowTarget>();
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public override void OnActivation(bool activated)
    {
        if (activated)
        {
            wasActivated = true;
        }
        if (wasActivated)
        {
            if(isLevelEnd)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                
                if(!rightBoundSet)
                {
                    // Set the new rightbounds for CameraEdgeSnapping
                    upEdgeSnapping.rightBound = nextRoom.rightPosition;
                    downEdgeSnapping.rightBound = nextRoom.rightPosition;
                    playerInput.currentRoomId = nextRoom.roomId;
                    rightBoundSet = true;
                }
                
                //Save the cameras position for easy manipulation
                Vector3 upCameraPosition = upEdgeSnapping.gameObject.transform.position;
                Vector3 downCameraPosition = downEdgeSnapping.gameObject.transform.position;

                //Disable CameraFollowTarget script so it does not disturb panning 
                if(upCameraFollow.enabled || downCameraFollow.enabled)
                {
                    upCameraFollow.enabled = false;
                    downCameraFollow.enabled = false;
                } 

                if (upCameraPosition.x >= upEdgeSnapping.CalculateMinX(leftBoundPositionX) && downCameraPosition.x >= downEdgeSnapping.CalculateMinX(leftBoundPositionX))
                {
                    //Move the Blockers;
                    //foreach (Transform item in blockers)
                    //{
                    //    Vector3 tempPos = item.position;
                    //    tempPos.x -= 1f;
                    //    item.position = tempPos;
                    //}

                    // Set the new leftbounds for CameraEdgeSnapping
                    upEdgeSnapping.leftBound = nextRoom.leftPosition;
                    downEdgeSnapping.leftBound = nextRoom.leftPosition;

                    //Enable CameraFollowTarget script
                    upCameraFollow.enabled = true;
                    downCameraFollow.enabled = true;
                    //Disable this script so it does not reapeat its self;
                    enabled = false;
                }
                else
                {
                    float distance = panningSpeed * Time.deltaTime;

                    foreach (Transform item in blockers)
                    {
                        Vector3 tempPos = item.position;
                        tempPos.x = newBlockerTarget.position.x;
                        item.position = tempPos;
                    }

                    // Move the cameras to the right
                    upCameraPosition.x += distance;
                    downCameraPosition.x += distance;
                    //Moves player to spawnpoint
                    if (eve.transform.position.x < nextRoom.eveSpawnPosition.position.x)
                    {
                        eve.Move(1, false);
                        dodo.Move(1, false);

                    }
                    // Update Cameras position
                    upEdgeSnapping.gameObject.transform.position = upCameraPosition;
                    downEdgeSnapping.gameObject.transform.position = downCameraPosition;
                }
                
            }
        }
    }
}