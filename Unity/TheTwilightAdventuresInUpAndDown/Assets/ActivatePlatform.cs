using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : ActionObject {

    private bool activated;
    PlatformController platformController;

    // Use this for initialization
    void Start () {
        platformController = GetComponent<PlatformController>();
        platformController.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (activated) {
            platformController.enabled = true;
        } else if (!activated) {
            platformController.enabled = false;
        }
    }

    public override void OnActivation(bool activated) {

        this.activated = activated;
    }
}
