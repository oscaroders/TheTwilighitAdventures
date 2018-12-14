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

        if(characterSwitch.isEve)
        {
            Focus("Eve");
            
            
        } else
        {
            Focus("Dodo");
        }


        if (characterSwitch.isEve && eveCameraCurrent < eveCameraProcentTotal)
        {
            eveCameraCurrent += procentSpeed;
        }
        else if (!characterSwitch.isEve && eveCameraCurrent > eveCameraProcentTotal)
        {
            eveCameraCurrent -= procentSpeed;
        }
        else
        {
            eveCameraCurrent = eveCameraProcentTotal;
        }

       
       if (!characterSwitch.isEve && dodoCameraCurrent < dodoCameraProcentTotal)
       {
            dodoCameraCurrent += procentSpeed;
       }
       else if(characterSwitch.isEve && dodoCameraCurrent > dodoCameraProcentTotal)
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
