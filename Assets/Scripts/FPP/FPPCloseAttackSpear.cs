using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPCloseAttackSpear : MonoBehaviour
{
    public enum attackDirection { none, down, up };
    public float maxMovement = 5.0f;
    public float currentMovement;
    public float attackSpeed = -10.0f;//when less 0 rotation direction is down else rotation direction is up
    public attackDirection attack;
    private Vector3 localScale;
    private Vector3 localPosition;

    public AudioClip MusicClipSwing;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start()
    {
        attack = attackDirection.none;
        currentMovement = 0;
        localScale = gameObject.transform.localScale;
        localPosition = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameVariables.GameMode == GameVariables.GameModes.Hero &&
            GameVariables.PlayerWeapon == GameVariables.PlayerWeapons.Close)
        {
            //weapon appears after weapon change
            if (gameObject.transform.localScale != localScale)
            {
                gameObject.transform.localScale = localScale;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }

            if (attack != attackDirection.none)
            {
                
                if (attack == attackDirection.down)
                {
                    if (MusicSource.isPlaying == false)
                    {
                        MusicSource.PlayOneShot(MusicClipSwing);
                    }
                    if (currentMovement > -maxMovement)
                    {
                        currentMovement += attackSpeed * Time.deltaTime;
                        //gameObject.transform.Translate(-1 * gameObject.GetComponentInParent<Transform>().right * attackSpeed * Time.deltaTime, Space.World);
                        gameObject.transform.Translate(-1 * gameObject.transform.up * attackSpeed * Time.deltaTime, Space.World);
                    }
                    else
                    {
                        attack = attackDirection.up;
                        attackSpeed *= -1;//change rotation direction
                        currentMovement = 0;
                    }
                }
                else if (attack == attackDirection.up)
                {
                    if (currentMovement < maxMovement)
                    {
                        currentMovement += attackSpeed * Time.deltaTime;
                        //gameObject.transform.Translate(-1 * gameObject.GetComponentInParent<Transform>().right * attackSpeed * Time.deltaTime, Space.World);
                        gameObject.transform.Translate(-1 * gameObject.transform.up * attackSpeed * Time.deltaTime, Space.World);
                    }
                    else
                    {
                        attack = attackDirection.none;
                        attackSpeed *= -1;//change rotation direction
                        currentMovement = 0;
                    }
                }


            }

            if (Input.GetMouseButtonDown(0) && attack == attackDirection.none)
            {
                attack = attackDirection.down;
            }
        }

        //weapon disappear after weapon change
        if (GameVariables.PlayerWeapon != GameVariables.PlayerWeapons.Close &&
            gameObject.transform.localScale == localScale)
        {
            //gameObject.GetComponent<MeshRenderer>().
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.transform.localPosition = localPosition;
        }





    }
}
