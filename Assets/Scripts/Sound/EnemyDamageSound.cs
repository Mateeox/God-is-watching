using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSound : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && MusicSource.isPlaying == false)
        {
            MusicSource.Play();
        }
    }
}
