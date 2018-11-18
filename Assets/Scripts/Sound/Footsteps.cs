using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    CharacterController cc;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

	void Start () {
        cc = GetComponent<CharacterController>();
        MusicSource.clip = MusicClip;
	}
	
	// Update is called once per frame
	void Update () {
		if(cc.isGrounded == true && cc.velocity.magnitude > 2f && MusicSource.isPlaying == false)
        {
            MusicSource.volume = Random.Range(0.1f, 0.3f);
            MusicSource.pitch = Random.Range(0.6f, 1.1f);
            MusicSource.Play();
        }
	}
}
