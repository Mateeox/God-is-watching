using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSound : MonoBehaviour {
    
    public AudioSource MusicSource;

    void Start () {
        MusicSource = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            MusicSource.Play();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
