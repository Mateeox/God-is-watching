using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioClip MusicGodClip;
    public AudioSource MusicSource;

    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if((MusicSource.isPlaying == true && GameVariables.GameMode == GameVariables.GameModes.God && MusicSource.clip == MusicClip) 
            ||(MusicSource.isPlaying == true && GameVariables.GameMode != GameVariables.GameModes.God && MusicSource.clip == MusicGodClip))
        {
            MusicSource.Stop();
        }

        if (GameVariables.GameMode == GameVariables.GameModes.God)
        {
            MusicSource.clip = MusicGodClip;
        }
        else
        {
            MusicSource.clip = MusicClip;
        }

		if(MusicSource.isPlaying == false)
        {
            MusicSource.Play();
        }
       
    }
}
