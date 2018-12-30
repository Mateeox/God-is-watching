using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TumbleWeedGenerator : MonoBehaviour {

    public GameObject tumbleweedPrefab;
    public List<GameObject> tumbleweeds;
    private System.Random randomGenerator = new System.Random();
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        int rndInt = randomGenerator.Next(1, 7500);
        if (rndInt >= 10 && rndInt <= 20)
        {
            float rndX = (float)randomGenerator.Next(-100, 100);
            float rndZ = (float)randomGenerator.Next(-50, -20);
            GameObject tumbleWeed = Instantiate(tumbleweedPrefab, new Vector3(rndX,1.2f,rndZ), Quaternion.identity) as GameObject;
            tumbleWeed.GetComponent<TumbleweedBehavior>().SetMinZ(rndZ);
            tumbleweeds.Add(tumbleWeed);
            Debug.Log(tumbleweeds.Count);
            if(tumbleweeds.Count >= 20)
            {
                Destroy(tumbleweeds[0]);
                tumbleweeds.RemoveAt(0);
            }
        }
    }
}
