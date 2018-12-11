using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveData data;
        
	void Start () {
        GameObject.Find("Continue");
        GameObject button = GameObject.Find("Continue");
        Debug.Log(Save.dataPath);
        if (!System.IO.File.Exists(Save.dataPath))
        {
            button.SetActive(false);
        }
    }

    private void Awake()
    {
        
    }

    void Update () {
		
	}

    
}
