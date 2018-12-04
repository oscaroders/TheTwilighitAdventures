using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScreenSpace : MonoBehaviour {

    public Camera mainCamera;
    public Camera eveCamera;
    public Camera dodoCamera;
    public Slider slider;

    public float defaultValueOfOrthographicSize;

    private void Start()
    {
        defaultValueOfOrthographicSize = mainCamera.orthographicSize;
    }
    float eveCameraProcent = 0.5f;
    float dodoCameraProcent = 0.5f;

    void LateUpdate () {
        mainCamera.orthographicSize = defaultValueOfOrthographicSize;

        eveCameraProcent = slider.value;
        dodoCameraProcent = 1 - slider.value;

        eveCamera.orthographicSize = defaultValueOfOrthographicSize * eveCameraProcent;
        dodoCamera.orthographicSize = defaultValueOfOrthographicSize * dodoCameraProcent;

        Rect temp = eveCamera.rect;
        temp.y = -eveCameraProcent + 1;
        eveCamera.rect = temp;

        temp = dodoCamera.rect;
        temp.y = dodoCameraProcent - 1;
        dodoCamera.rect = temp;

        //Vector3 t = dodoCamera.transform.position;
        //t.x = eveCamera.transform.position.x;
        //dodoCamera.transform.position = t;
    }
}
