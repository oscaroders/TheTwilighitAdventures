using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScreenSpace : MonoBehaviour {

    public Camera eveCamera;
    public Camera dodoCamera;
    public Slider slider;

    float eveCameraProcent = 0.5f;
    float dodoCameraProcent = 0.5f;
    // Update is called once per frame
    void LateUpdate () {


        eveCameraProcent = slider.value;
        dodoCameraProcent = 1 - slider.value;

        eveCamera.orthographicSize = 5 * eveCameraProcent;
        dodoCamera.orthographicSize = 5 * dodoCameraProcent;

        Rect temp = eveCamera.rect;
        temp.y = -eveCameraProcent + 1;
        eveCamera.rect = temp;


        temp = dodoCamera.rect;
        temp.y = dodoCameraProcent - 1;
        dodoCamera.rect = temp;

    }
}
