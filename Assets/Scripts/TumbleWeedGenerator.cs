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
        int rndInt = randomGenerator.Next(1, 500);
        if (rndInt >= 10 && rndInt <= 20)
        {
            float rndX = (float)randomGenerator.Next(-10, 10);
            float rndZ = (float)randomGenerator.Next(-300, -100);
            Debug.Log(rndZ);
            GameObject tumbleWeed = Instantiate(tumbleweedPrefab, new Vector3(rndX,1.2f,rndZ), Quaternion.identity) as GameObject;
            tumbleWeed.GetComponent<TumbleweedBehavior>().SetMinZ(rndZ);
            tumbleweeds.Add(tumbleWeed);
            if(tumbleweeds.Count+1 > 10)
            {
                Debug.Log("Deleted tumbleweed!");
                tumbleweeds.RemoveAt(0);
            }
        }
    }
}
