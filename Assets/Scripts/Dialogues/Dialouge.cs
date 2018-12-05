using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge {

    public string characterName;

    [TextArea(1,10)]
	public string[] sentences;
}
