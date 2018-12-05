using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfRoom : ActionObject
{
    [SerializeField] private bool isLevelEnd;
    [SerializeField] private string sceneName;
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
                //Pan the camera to the next room
            }
        }
    }
}