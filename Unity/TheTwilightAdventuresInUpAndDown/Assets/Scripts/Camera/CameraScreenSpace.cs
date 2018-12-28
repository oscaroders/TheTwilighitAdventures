using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScreenSpace : MonoBehaviour {

    public Camera mainCamera;
    public Camera eveCamera;
    public Camera dodoCamera;
    [Range(0,1)]
    public float focusProcentage = 0.7f;

    public float defaultValueOfOrthographicSize;
    public bool otherCameraFollowX;
    public bool otherCameraFollowY;
    private CharacterSwitch characterSwitch;

    internal float eveCameraProcentTotal;
    internal float dodoCameraProcentTotal;
    internal float eveCameraCurrent;
    internal float dodoCameraCurrent;

    [Range(0.010f,0.005f)]
    public float procentSpeed = 0.01f;

    private void Start()
    {
        defaultValueOfOrthographicSize = mainCamera.orthographicSize;
        characterSwitch = GetComponent<CharacterSwitch>();
        Focus("Eve");
        eveCameraCurrent = eveCameraProcentTotal;
        dodoCameraCurrent = dodoCameraProcentTotal;
    }
    void LateUpdate () {

        if(true)
        {
            Focus("Eve");
            
            
        } else
        {
            Focus("Dodo");
        }


        if (true && eveCameraCurrent < eveCameraProcentTotal)
        {
            eveCameraCurrent += procentSpeed;
        }
        else if (!true && eveCameraCurrent > eveCameraProcentTotal)
        {
            eveCameraCurrent -= procentSpeed;
        }
        else
        {
            eveCameraCurrent = eveCameraProcentTotal;
        }

       
       if (!true && dodoCameraCurrent < dodoCameraProcentTotal)
       {
            dodoCameraCurrent += procentSpeed;
       }
       else if(true && dodoCameraCurrent > dodoCameraProcentTotal)
       {
            dodoCameraCurrent -= procentSpeed;
       }
       else
       {
            dodoCameraCurrent = dodoCameraProcentTotal;
       }
       

        mainCamera.orthographicSize = defaultValueOfOrthographicSize;

        eveCamera.orthographicSize = defaultValueOfOrthographicSize * eveCameraCurrent;
        dodoCamera.orthographicSize = defaultValueOfOrthographicSize * dodoCameraCurrent;

       


        Rect temp = eveCamera.rect;
        temp.y = -eveCameraCurrent + 1;
        eveCamera.rect = temp;

        temp = dodoCamera.rect;
        temp.y = dodoCameraCurrent - 1;
        dodoCamera.rect = temp;

        if (otherCameraFollowX)
        {
            if (true)
            {
                dodoCamera.transform.position = new Vector3(eveCamera.transform.position.x, dodoCamera.transform.position.y, dodoCamera.transform.position.z);
            }
            else
            {
                eveCamera.transform.position = new Vector3(dodoCamera.transform.position.x, eveCamera.transform.position.y, eveCamera.transform.position.z);
            }
        }
    }

    void Focus(string name)
    {
        if(name == "Eve")
        {
            eveCameraProcentTotal = focusProcentage;
            dodoCameraProcentTotal = 1 - focusProcentage;
        }
        else if(name == "Dodo")
        {
            dodoCameraProcentTotal = focusProcentage;
            eveCameraProcentTotal = 1 - focusProcentage;
        }

    }
        

}
