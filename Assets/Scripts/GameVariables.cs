using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour {

    public enum GameModes { Herose, God};
    public static GameModes GameMode { get; private set; }

    void Start () {
        GameMode = GameModes.Herose;
	}
	
	void Update () {
        if (Input.GetButtonDown("ChangeMode"))
        {
            if(GameMode == GameModes.Herose)
            {
                GameMode = GameModes.God;
            }
            else
            {
                GameMode = GameModes.Herose;
            }
        }
	}
}
