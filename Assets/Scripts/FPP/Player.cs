using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static GameObject pickedObject;
    public static float maxPickUpDistance;
    private GameObject Checkpoint;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public Texture texture;
    public float hittedTime = 0.1f;
    public float hittedCounter;
    public bool playerHitted;

    public Texture deadTexture;
    public bool isDead = false;
    public float deadAnimationTime = 0.8f;
    public float deadAnimationCounter;


    private CharacterController characterController;

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
        if (GlobalControl.Set)
        {
            transform.position = GlobalControl.Position;
            transform.rotation = GlobalControl.Rotation;
        }
        pickedObject = null;
        maxPickUpDistance = 4.0f;
		healthBar.init(100.0f, 100.0f);
		manaBar.init(100.0f, 100.0f);
		lightningBolt = GameObject.FindGameObjectWithTag("LightningBolt").GetComponent<LightningBoltScript>();
        playerHitted = false;
        hittedCounter = 0.0f;
        characterController = GetComponent<CharacterController>();
        isDead = false;
        deadAnimationCounter = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {

        if (playerHitted)
        {
            if (hittedCounter < hittedTime)
            {
                hittedCounter += Time.deltaTime;
            }
            else
            {
                hittedCounter = 0.0f;
                playerHitted = false;
            }

        }

        if(isDead)
        {
            if (deadAnimationCounter < deadAnimationTime)
            {
                deadAnimationCounter += Time.deltaTime;
            }
            else
            {
                deadAnimationCounter = 0.0f;
                isDead = false;
            }

        }

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
		/*if (Input.GetKeyDown(KeyCode.I))
		{
			takeDamage(-10);
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			takeDamage(10);
		}*/
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
		if (manaBar.Value < manaBar.MaxValue)
		{
			takeDamage(subtractFactor);
			manaBar.addValue(addFactor);
		}
	}
	
	
	public void takeDamage(float damage)
	{
		playerHitted = true;
        MusicSource.volume = 2.7f;
        MusicSource.pitch = Random.Range(0.8f, 1.1f);
        MusicSource.PlayOneShot(MusicClip);
        healthBar.addValue(-damage);
		if (healthBar.Value < 0.0001f)
		{
            //player is dead...
            GameVariables.DisableWeapons();
            GameVariables.ChangeToHero();
            isDead = true;
            
            if (Checkpoint != null)
            {
                Vector3 checkpointPos = Checkpoint.transform.position;
				GlobalControl.Set = true;
                GlobalControl.Position = new Vector3(checkpointPos.x, checkpointPos.y + 2.0f, checkpointPos.z + 2.0f);
                GlobalControl.Rotation = new Quaternion(0, 0.7f, 0, 1.0f);
            }
           
            Die();
        }
    }

      
    private void Die()
    {
        isDead = true;
        MoveToLastCheckPoint();
        GameVariables.EnableWeapons();
       //Restart of the scene 15.12.2018 - removed due to change of respawn concept
       //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private void MoveToLastCheckPoint()
    {
        if (GlobalControl.Set)
        {
            transform.position = GlobalControl.Position;
            transform.rotation = GlobalControl.Rotation;

            Camera _heroCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            _heroCam.transform.parent = transform;
            _heroCam.transform.localPosition = new Vector3(0.07f, 0.37f, -0.03f);
            _heroCam.transform.localRotation = new Quaternion();
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SetCheckpoint(GameObject checkpoint, bool isBoss)
    {
        if (!isBoss)
        {
            FullMana();
        }
        FullHealth();
        this.Checkpoint = checkpoint;
    }

    private void FullMana()
    {
        manaBar.addValue(manaBar.MaxValue - manaBar.Value);
    }

    private void FullHealth()
    {
        healthBar.addValue(1000000);
    }

    void useMana(float amount)
	{
		manaBar.addValue(-amount);
	}
	
	public void beforeBossConversion() 
	{
		if (manaBar.Value + healthBar.Value > healthBar.MaxValue) {
			healthBar.boostMaxValue(manaBar.Value + healthBar.Value);
		}
		else {
			healthBar.addValue(manaBar.Value);
		}
		manaBar.addValue(-manaBar.Value);
	}

    private void OnGUI()
    {
        if (playerHitted && !isDead)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }

        if (isDead)
        {
            //float scale = deadAnimationTime / (deadAnimationTime - deadAnimationCounter);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), deadTexture);
        }
    }
    
}
