using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTutorialCanvasScript : MonoBehaviour {

    private bool pressedW = false;
    private bool pressedS = false;
    private bool pressedA = false;
    private bool pressedD = false;
    private GameObject wImage;
    private GameObject sImage;
    private GameObject aImage;
    private GameObject dImage;
    public Color32 changeColor;
    public GameObject nextTutorial;
    public float delayTime;
    // Use this for initialization
    void Start () {
        wImage = GameObject.Find("imageW");
        sImage = GameObject.Find("imageS");
        aImage = GameObject.Find("imageA");
        dImage = GameObject.Find("imageD");

    }

    void ShowAnotherTutorial()
    {
        nextTutorial.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) && pressedW == false)
        {
            pressedW = true;
            wImage.GetComponent<Image>().color = changeColor;
        }
        else if (Input.GetKeyDown(KeyCode.S) && pressedS == false)
        {
            pressedS = true;
            sImage.GetComponent<Image>().color = changeColor;
        }
        else if (Input.GetKeyDown(KeyCode.A) && pressedA == false)
        {
            pressedA = true;
            aImage.GetComponent<Image>().color = changeColor;
        }
        else if (Input.GetKeyDown(KeyCode.D) && pressedD == false)
        {
            pressedD = true;
            dImage.GetComponent<Image>().color = changeColor;
        }

        if (pressedW && pressedS && pressedA && pressedD)
        {
            Invoke("ShowAnotherTutorial", delayTime);
            Destroy(this.gameObject, delayTime);      
        }

    }
}
