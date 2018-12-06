using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScreenSpace : MonoBehaviour {

    public Camera mainCamera;
    public Camera eveCamera;
    public Camera dodoCamera;
    [Range(0,1)]public float focusProcentage = 0.7f;

    public float defaultValueOfOrthographicSize;

    private CharacterSwitch characterSwitch;

    float eveCameraProcent;
    float dodoCameraProcent;

    private void Start()
    {
        defaultValueOfOrthographicSize = mainCamera.orthographicSize;
        characterSwitch = GetComponent<CharacterSwitch>();
        Focus("Eve");
    }
    void LateUpdate () {

        if(characterSwitch.isEve)
        {
            Focus("Eve");
        } else
        {
            Focus("Dodo");
        }

        mainCamera.orthographicSize = defaultValueOfOrthographicSize;

        eveCamera.orthographicSize = defaultValueOfOrthographicSize * eveCameraProcent;
        dodoCamera.orthographicSize = defaultValueOfOrthographicSize * dodoCameraProcent;

        Rect temp = eveCamera.rect;
        temp.y = -eveCameraProcent + 1;
        eveCamera.rect = temp;

        temp = dodoCamera.rect;
        temp.y = dodoCameraProcent - 1;
        dodoCamera.rect = temp;
    }

    void Focus(string name)
    {
        if(name == "Eve")
        {
            eveCameraProcent = focusProcentage;
            dodoCameraProcent = 1 - focusProcentage;
        }
        else if(name == "Dodo")
        {
            dodoCameraProcent = focusProcentage;
            eveCameraProcent = 1 - focusProcentage;
        }

    }
        

}
