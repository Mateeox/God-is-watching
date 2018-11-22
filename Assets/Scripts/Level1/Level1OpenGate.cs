using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1OpenGate : MonoBehaviour {

    public GameObject[] leftChain;
    public GameObject leftChainHolder;
    public GameObject[] rightChain;
    public GameObject rightChainHolder;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       
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
