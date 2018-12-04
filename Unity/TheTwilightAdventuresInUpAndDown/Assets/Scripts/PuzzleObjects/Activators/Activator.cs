using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public PuzzleAction[] puzzlePieces;
    public bool stateOfActivator;
    public void Activate(bool state)
    {
        stateOfActivator = state;
        foreach (PuzzleAction puzzlePiece in puzzlePieces)
        {
            puzzlePiece.OnActivation(state);
        }
    }
}