﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
public class ObjectGodThunder : MonoBehaviour {

	public GameObject AfterThunderRemainder;

	private LightningBoltScript lightningBolt;
	
	void Start() {
		lightningBolt = GameObject.FindGameObjectWithTag("LightningBolt").GetComponent<LightningBoltScript>();
	}
	void OnMouseDown() {
		if (GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Thunder)
		{
			lightningBolt.setPositions(GameVariables.getPos());
			lightningBolt.Trigger();
			if (this.CompareTag("Terrain"))
			{
				Instantiate(AfterThunderRemainder, GameVariables.getPos(), Quaternion.identity);
			}
			else
			{
				Instantiate(AfterThunderRemainder, this.transform.position, this.transform.rotation);
				Destroy(this.gameObject);
			}
		}
	}
}