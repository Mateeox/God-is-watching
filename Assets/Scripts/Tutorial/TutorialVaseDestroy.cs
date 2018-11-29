using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVaseDestroy : MonoBehaviour {
       
    public bool isDestroyed;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start () {
        isDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDestroy()
    {
        if (!isDestroyed)
        {
            MusicSource.PlayOneShot(MusicClip);

            isDestroyed = true;
        }
        
    }
}
