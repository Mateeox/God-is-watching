using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    CharacterController cc;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(cc.isGrounded == true && cc.velocity.magnitude > 2f && MusicSource.isPlaying == false)
        {
            MusicSource.volume = Random.Range(0.04f, 0.07f);
            MusicSource.pitch = Random.Range(0.5f, 0.9f);
            MusicSource.Play();
        }
	}
}
