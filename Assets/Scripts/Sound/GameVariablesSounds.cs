using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariablesSounds : MonoBehaviour {

    public AudioClip MusicClipThunder;
    public AudioClip MusicClipTime;
    public AudioSource MusicSource;
    public static Camera godCam;

    void Start()
    {

    }

    void Update ()
    {
        if (GameVariables.GameMode == GameVariables.GameModes.God)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3)) 
            {
                MusicSource.pitch = 1f;
                MusicSource.PlayOneShot(MusicClipTime);
            }
            else if (GameVariables.Ability == GameVariables.Abilities.Thunder && Input.GetMouseButtonDown(0) == true)
            {
                MusicSource.pitch = 2f;
                MusicSource.PlayOneShot(MusicClipThunder);
            }
        }
    }

}
