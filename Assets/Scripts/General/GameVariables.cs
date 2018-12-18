using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{

    public enum GameModes { Hero, God };
    public enum PlayerWeapons { None, Range, Close};
    public enum Abilities { Move, Thunder=10, Time=40 };
    public static Abilities Ability { get; private set; }
    public static GameModes GameMode { get; private set; }
    public static PlayerWeapons PlayerWeapon { get; private set; }
    public static Camera godCam;

    void Start()
    {
        GameMode = GameModes.Hero;
		Ability = Abilities.Move;
        PlayerWeapon = PlayerWeapons.None;
        godCam = GameObject.FindGameObjectWithTag("GodCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        if (Input.GetButtonDown("ChangeMode"))
        {
            if (GameMode == GameModes.Hero)
            {
                GameMode = GameModes.God;
            }
            else
            {
                GameMode = GameModes.Hero;
            }
        }

        if (GameMode == GameModes.God)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Ability = Abilities.Move;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Ability = Abilities.Thunder;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Ability = Abilities.Time;
            }
        }

        if (GameMode == GameModes.Hero)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {

                if (PlayerWeapon == PlayerWeapons.Close)
                {
                    PlayerWeapon = PlayerWeapons.None;
                }
                else
                {
                    PlayerWeapon++;
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (PlayerWeapon == PlayerWeapons.None)
                {
                    PlayerWeapon = PlayerWeapons.Close;
                }
                else
                {
                    PlayerWeapon--;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlayerWeapon = PlayerWeapons.None;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PlayerWeapon = PlayerWeapons.Close;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PlayerWeapon = PlayerWeapons.Range;
            }
        }
    }

    public static Vector3 getPos()
    {
        RaycastHit RayHit;
        Ray ray;
        ray = godCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RayHit))
        {
            return RayHit.point;
        }
        return Vector3.zero;
    }
    public static GameObject getObjectHit()
    {
        RaycastHit RayHit;
        Ray ray;
        ray = godCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RayHit))
        {
            GameObject ObjectHit = RayHit.transform.gameObject;
            if (ObjectHit != null)
            {
                return ObjectHit;
            }
        }
        return null;
    }
}