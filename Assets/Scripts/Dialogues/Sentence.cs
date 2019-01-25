using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence
{
    [TextArea]
    public string text;
    [Header("Keys relation (true - and, false - xor)")]
    public bool relation = true;
    [TextArea(1, 10)]
    public List<string> endingKeys;
}
