using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaHealthSound : MonoBehaviour {

    public AudioClip AudioClip;
    public AudioSource AudioSource;

// Use this for initialization
void Start () {
        
    }

// Update is called once per frame
void Update() {
    if ((Input.GetKey(KeyCode.H) && !AudioSource.isPlaying ) || (Input.GetKey(KeyCode.M)) && !AudioSource.isPlaying)
    {
            AudioSource.volume = 0.4f;
            AudioSource.PlayOneShot(AudioClip);
    }
}
}
