using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPCloseAttack : MonoBehaviour {
    public enum attackDirection { none, down, up};
    public float maxRotation = 45.0f;
    public float currentRotation;
    public float attackSpeed = -10.0f;//when less 0 rotation direction is down else rotation direction is up
    public attackDirection attack;
    private Vector3 localScale;

	// Use this for initialization
	void Start () {
        attack = attackDirection.none;
        currentRotation = 0;
        localScale = gameObject.transform.localScale;
	}

    // Update is called once per frame
    void Update() {

        if(GameVariables.GameMode == GameVariables.GameModes.Hero && 
            GameVariables.PlayerWeapon == GameVariables.PlayerWeapons.Close)
        {
            //weapon appears after weapon change
            if (gameObject.transform.localScale != localScale)
            {
                 gameObject.transform.localScale = localScale;
            }

            if (attack != attackDirection.none)
            {
                float angle = attackSpeed * Time.deltaTime;
                currentRotation += angle;
                if (attack == attackDirection.down)
                {
                    if (currentRotation > -maxRotation)
                    {
                        gameObject.transform.Rotate(transform.forward * angle, Space.World);
                    }
                    else
                    {
                        attack = attackDirection.up;
                        attackSpeed *= -1;//change rotation direction
                        currentRotation = 0;
                    }
                }
                else if (attack == attackDirection.up)
                {
                    if (currentRotation < maxRotation)
                    {
                        gameObject.transform.Rotate(transform.forward * angle, Space.World);
                    }
                    else
                    {
                        attack = attackDirection.none;
                        attackSpeed *= -1;//change rotation direction
                        currentRotation = 0;
                    }
                }


            }

            if (Input.GetMouseButtonDown(0) && attack == attackDirection.none)
            {
                attack = attackDirection.down;
            }
        }
       
        //weapon disappear after weapon change
        if(GameVariables.PlayerWeapon != GameVariables.PlayerWeapons.Close &&
            gameObject.transform.localScale == localScale)
        {
            //gameObject.GetComponent<MeshRenderer>().
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
            
        
        


    }
}
