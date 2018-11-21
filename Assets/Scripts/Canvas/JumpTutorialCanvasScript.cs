using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpTutorialCanvasScript : MonoBehaviour
{

    private bool pressedSpace = false;
    private GameObject spaceImage;
    public Color32 changeColor;
    public GameObject nextTutorial;
    public float delayTime;
    // Use this for initialization
    void Start()
    {
        spaceImage = GameObject.Find("imageSpace");

    }

    void ShowAnotherTutorial()
    {
        nextTutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pressedSpace == false)
        {
            pressedSpace = true;
            spaceImage.GetComponent<Image>().color = changeColor;
        }

        if (pressedSpace)
        {
            Destroy(this.gameObject, delayTime);
        }

    }
}
