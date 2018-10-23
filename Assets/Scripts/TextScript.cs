using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScript : MonoBehaviour
{

    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;

    // Use this for initialization
    void Start()
    {
        print(GameObject.Find("Rocks_canvas").ToString());
        myText = GameObject.Find("Rocks_text").GetComponent<Text>();
        myText.color = Color.clear;
        //Screen.showCursor = false;
        //Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        FadeText();
    }

    void OnMouseOver()
    {
        displayInfo = true;

    }



    void OnMouseExit()

    {
        displayInfo = false;

    }


    void FadeText()

    {


        if (displayInfo)
        {

            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }

        else
        {

            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }




    }



}