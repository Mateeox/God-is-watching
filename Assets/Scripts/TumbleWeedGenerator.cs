using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TumbleWeedGenerator : MonoBehaviour {

    public GameObject tumbleweedPrefab;
    public List<GameObject> tumbleweeds;
    private System.Random randomGenerator = new System.Random();
    public int minX = -100;
    public int maxX = 100;
    public int minZ = -50;
    public int maxZ = -20;
    public int maxWeedNumber = 20;
    public int minRand = 10;
    public int maxRand = 20;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        int rndInt = randomGenerator.Next(1, 7500);
        if (rndInt >= minRand && rndInt <= maxRand)
        {
            float rndX = (float)randomGenerator.Next(minX, maxX);
            float rndZ = (float)randomGenerator.Next(minZ, maxZ);
            GameObject tumbleWeed = Instantiate(tumbleweedPrefab, new Vector3(rndX,1.2f,rndZ), Quaternion.identity) as GameObject;
            tumbleWeed.GetComponent<TumbleweedBehavior>().SetMinZ(rndZ);
            tumbleweeds.Add(tumbleWeed);
            Debug.Log(tumbleweeds.Count);
            if(tumbleweeds.Count >= maxWeedNumber)
            {
                Destroy(tumbleweeds[0]);
                tumbleweeds.RemoveAt(0);
            }
        }
    }
}
