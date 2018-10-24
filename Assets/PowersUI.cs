using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
        {
            print("Clicked");
            if (GameVariables.Ability == GameVariables.Abilities.Move)
            {
                GameObject.Find("TimeImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("MoveImage").GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            }
            else if (GameVariables.Ability == GameVariables.Abilities.Time)
            {
                GameObject.Find("MoveImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("TimeImage").GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            } else if (GameVariables.Ability == GameVariables.Abilities.Thunder)
            {
                GameObject.Find("MoveImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("TimeImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderImage").GetComponent<Image>().color = new Color32(0, 0, 0, 255);

            }
        }
	}
}
