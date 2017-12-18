using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	//What every monster needs
	private int[] stats = new Array[13]; 
	/*
	stats for the monster, in the following order:
	LIF (1-999): HP of the monster
	POW (1-999): Physical power of the monster; affects physical attack damage and ability to move obstacles while on adventures
	INT (1-999): Intellectual power of the monster; affects mental attack damage/defense and ability to find alternate routes while on adventures
	SKI (1-999): Monster's ability to hit enemies in battle
	SPD (1-999): Monster's ability to evade enemy attacks
	DEF (1-999): Monster's ability to endure enemy physical attacks
	LOYALTY (0-100): Monster's loyalty to its trainer.  The lower it is, the more foolerys it will commit in battle.
	LIFESPAN (0-600): # of weeks in a monster's life.  When it hits zero, monster dies.
	STRESS (0-100): How stressed out a monster is, the lower the better.  High stress results in runaways and reduced lifespan.
	FATIGUE (0-100): How fatigued a monster is, the lower the better.  High fatigue results in increased injury risk, increased training failure, and reduced lifespan.
	DISCIPLINE (-100-100): How disciplined a monster is.  At high values, the monster will live longer, but have reduced loyalty and worse training results; at lower values, 
						   the monster will train more effectively, but have increased stress and reduced loyalty at the extreme.  Being in the middle is a good thing.
	FORM (-100-100): How fat or skinny a monster is.  Being fat reduces damage taken, but also reduces evasion; being skinny does the opposite (increased damage taken, increased evasion).
	CLUTCH (-100-100): A random, hidden stat that increases with wins in critical condition (<15% health, maybe????).  The higher a monster's clutch, the better they will perform in critical condition.
	*/
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
