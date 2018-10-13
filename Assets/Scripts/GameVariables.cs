using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour {

    public enum GameModes { Hero, God };
    public static GameModes GameMode { get; private set; }

    void Start () {
        GameMode = GameModes.Hero;
	}
	
	void Update () {
        if (Input.GetButtonDown("ChangeMode"))
        {
            if(GameMode == GameModes.Hero)
            {
                GameMode = GameModes.God;
            }
            else
            {
                GameMode = GameModes.Hero;
            }
        }
	}
}
