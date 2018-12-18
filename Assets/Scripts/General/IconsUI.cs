using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconsUI : MonoBehaviour
{

    private GameObject powerPanel;
    private GameObject heroPanel;

    private void Awake()
    {
        powerPanel = transform.Find("PowersPanel").gameObject;
        heroPanel = transform.Find("HeroPanel").gameObject;
        powerPanel.SetActive(false);
        heroPanel.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.GameMode == GameVariables.GameModes.God)
        {
            powerPanel.SetActive(true);
            heroPanel.SetActive(false);
        }
        else
        {
            powerPanel.SetActive(false);
            heroPanel.SetActive(true);
        }

        if (GameVariables.GameMode == GameVariables.GameModes.God)
        {
            if (GameVariables.Ability == GameVariables.Abilities.Move)
            {
                GameObject.Find("TimeImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("TimeText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("MoveImage").GetComponent<Image>().color = new Color32(255, 255, 255, 204);
                GameObject.Find("MoveText").GetComponent<Text>().color = new Color32(255, 255, 255, 204);
            }
            else if (GameVariables.Ability == GameVariables.Abilities.Time)
            {
                GameObject.Find("MoveImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("MoveText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("TimeImage").GetComponent<Image>().color = new Color32(255, 255, 255, 204);
                GameObject.Find("TimeText").GetComponent<Text>().color = new Color32(255, 255, 255, 204);
            }
            else if (GameVariables.Ability == GameVariables.Abilities.Thunder)
            {
                GameObject.Find("MoveImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("TimeImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("MoveText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("TimeText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("ThunderImage").GetComponent<Image>().color = new Color32(255, 255, 255, 204);
                GameObject.Find("ThunderText").GetComponent<Text>().color = new Color32(255, 255, 255, 204);
            }
        }
        else
        {
            if (GameVariables.PlayerWeapon == GameVariables.PlayerWeapons.None)
            {
                GameObject.Find("CloseImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("RangedImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("CloseText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("RangedText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("NoneImage").GetComponent<Image>().color = new Color32(255, 255, 255, 204);
                GameObject.Find("NoneText").GetComponent<Text>().color = new Color32(255, 255, 255, 204);
            }
            else if (GameVariables.PlayerWeapon == GameVariables.PlayerWeapons.Close)
            {
                GameObject.Find("NoneImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("RangedImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("NoneText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("RangedText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("CloseImage").GetComponent<Image>().color = new Color32(255, 255, 255, 204);
                GameObject.Find("CloseText").GetComponent<Text>().color = new Color32(255, 255, 255, 204);
            }
            else if (GameVariables.PlayerWeapon == GameVariables.PlayerWeapons.Range)
            {
                GameObject.Find("CloseImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("NoneImage").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("NoneText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("CloseText").GetComponent<Text>().color = new Color32(0, 0, 0, 100);
                GameObject.Find("RangedImage").GetComponent<Image>().color = new Color32(255, 255, 255, 204);
                GameObject.Find("RangedText").GetComponent<Text>().color = new Color32(255, 255, 255, 204);
            }
        }
    }
}
