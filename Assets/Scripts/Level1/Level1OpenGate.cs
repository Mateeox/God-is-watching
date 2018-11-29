using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1OpenGate : MonoBehaviour {

    public GameObject[] leftChain;
    public GameObject leftChainHolder;
    public GameObject[] rightChain;
    public GameObject rightChainHolder;

    public AudioSource AudioSource;
    bool AlreadyPlayed = false;

    // Use this for initialization
    void Start () {
        AudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rightChainHolder == null && leftChainHolder == null && AudioSource.isPlaying == false && AlreadyPlayed == false)
        {
            AlreadyPlayed = true;
            AudioSource.Play();
        }
    }

    public void OnLeftChainDestroy()
    {
        foreach (var item in leftChain)
        {
            if (item.GetComponent<Rigidbody>() == null)
            {
                item.AddComponent((typeof(Rigidbody)));
            }
        }

        if (leftChainHolder != null)
        {
            GameObject.Destroy(leftChainHolder);
            leftChainHolder = null;
        }
    }

    public void OnRightChainDestroy()
    {
        foreach (var item in rightChain)
        {
            if(item.GetComponent<Rigidbody>() == null)
            {
                item.AddComponent((typeof(Rigidbody)));
            }
            
        }

        if(rightChainHolder != null)
        {
            GameObject.Destroy(rightChainHolder);
            rightChainHolder = null;
        }
       
    }
}
