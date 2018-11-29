using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinniteObject : MonoBehaviour {

    private bool isDuplicated;

    // Use this for initialization
    void Start () {
        isDuplicated = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (!isDuplicated && GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Move)
        {
            Instantiate(gameObject);
            isDuplicated = true;
        }

    }
}
