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

    public Transform[] blockers;

    public Transform nextRoomLeft;
    public Transform nextRoomRight;

    private void Start()
    {
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
        

    }

    public override void OnActivation(bool activated)
    {
        if (activated)
        {
            if(isLevelEnd)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                upEdgeSnapping.leftBound = nextRoomLeft;
                upEdgeSnapping.rightBound = nextRoomRight;

                downEdgeSnapping.leftBound = nextRoomLeft;
                downEdgeSnapping.rightBound = nextRoomRight;
                //Pan the camera to the next room
                foreach (Transform item in blockers)
                {
                    Vector3 tempPos = item.position;
                    tempPos.x -= 1f;
                    item.position = tempPos;
                }
                this.enabled = false;
            }
        }
    }
}