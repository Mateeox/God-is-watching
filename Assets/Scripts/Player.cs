using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static GameObject pickedObject;
    public static float maxPickUpDistance;
	
	//Abilities
	[SerializeField]
	private SlowZone slowZone;
	private LightningBoltScript lightningBolt;
	
	//UI bars
	[SerializeField]
	private UIBar healthBar;
	[SerializeField]
	private UIBar manaBar;
	
	//used for health <--> mana convesrion (both ways)
	private float addFactor = 0.4f;
	private float subtractFactor = 0.8f;
	// Use this for initialization
	void Start () {
        pickedObject = null;
        maxPickUpDistance = 4.0f;
		healthBar.init(100.0f, 100.0f);
		manaBar.init(100.0f, 100.0f);
		lightningBolt = GameObject.FindGameObjectWithTag("LightningBolt").GetComponent<LightningBoltScript>();
	}
	
	// Update is called once per frame
	void Update () {
		bool isTooLittleMana = false;
		if (slowZone.manualUpdate(manaBar.Value, ref isTooLittleMana))
		{
			useMana((int)GameVariables.Abilities.Time);
		}
		if (GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Thunder 
			&& Input.GetButtonDown("Fire1"))
		{
			if (manaBar.Value >= (int)GameVariables.Abilities.Thunder)
			{
				useMana((int)GameVariables.Abilities.Thunder);
				lightningBolt.setPositions(GameVariables.getPos());
				lightningBolt.Trigger();
				GameObject objectHit = GameVariables.getObjectHit();
				if (objectHit != null)
				{
					LightningHitable hitableObject = objectHit.GetComponent<LightningHitable>();
					if (hitableObject != null)
					{
						hitableObject.afterHit();
					}
				}
			}
			else
			{
				//not enough mana!!!oneoneone
				Debug.Log("Too little mana for thunder");
				isTooLittleMana = true;
			}
		}
		if (isTooLittleMana)
		{
			manaBar.blink();
		}
				
		if (Input.GetKey(KeyCode.H))
		{
				manaToHealth();
		}
		if (Input.GetKey(KeyCode.M))
		{
				healthToMana();
		}
		
		//***********************************
		//for debug only!
		if (Input.GetKeyDown(KeyCode.I))
		{
			takeDamage(-10);
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			takeDamage(10);
		}
		//***********************************

	}
	
	void manaToHealth()
	{
		if (manaBar.Value >= subtractFactor && healthBar.Value < healthBar.MaxValue)
		{
			manaBar.addValue(-subtractFactor);
			healthBar.addValue(addFactor);
		}
	}
	
	void healthToMana()
	{
		if (healthBar.Value >= subtractFactor && manaBar.Value < manaBar.MaxValue)
		{
			healthBar.addValue(-subtractFactor);
			manaBar.addValue(addFactor);
		}
	}
	
	
	public void takeDamage(float damage)
	{
		healthBar.addValue(-damage);
		if (healthBar.Value < 0.0001f)
		{
			//player is dead...
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	
	void useMana(float amount)
	{
		manaBar.addValue(-amount);
	}
}
