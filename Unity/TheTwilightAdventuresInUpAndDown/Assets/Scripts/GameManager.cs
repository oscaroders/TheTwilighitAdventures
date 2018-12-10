using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameState currentState;

    public enum GameState
    {
        MainMenu,
        Game,
        PauseMenu,
        LoadCheckpoint,
        Cinematic,
    }

    

// Use this for initialization
void Start () {
        if (instance == null)
                instance = this;
        
        else
                Destroy (this);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.MainMenu:
                //Run MainMenu
                SceneManager.LoadScene("Main Menu");
                break;

            case GameState.Game:
                //Run Game
                SceneManager.LoadScene("MVP");
                break;

            case GameState.PauseMenu:
                //Run PauseMenu
                break;

            case GameState.LoadCheckpoint:
                //Run Load last checkpoint script
                break;

            case GameState.Cinematic:
                //Run Cinematic thingies
                break;

            default:
                break;
        }
    }
}
