﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternControll : MonoBehaviour {

    public GameObject lanterLight;
    public float amountOfLanternFuel;
     // [HideInInspector]
    public bool hasEveLantern;

	// Use this for initialization
	void Start () {
		
	}
	
	// Make into a function when we know from where to call it.
	void Update () {

        if (hasEveLantern) {
            lanterLight.SetActive(true);
        } else {
            lanterLight.SetActive(false);
        }
    }

    void SetSizeOfLight(float percentage) {
        float tmp = percentage / 100;
        tmp = Mathf.Clamp(tmp, .2f, 1f); 

        lanterLight.transform.localScale = new Vector3(lanterLight.transform.localScale.x * tmp, lanterLight.transform.localScale.y * tmp, lanterLight.transform.localScale.z);
    }
}