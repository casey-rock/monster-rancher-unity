using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	//What every monster needs

	/*
	stats for the monster, in the following order:
	0 LIF (1-999): HP of the monster
	1 POW (1-999): Physical power of the monster; affects physical attack damage and ability to move obstacles while on adventures
	2 INT (1-999): Intellectual power of the monster; affects mental attack damage/defense and ability to find alternate routes while on adventures
	3 SKI (1-999): Monster's ability to hit enemies in battle
	4 SPD (1-999): Monster's ability to evade enemy attacks
	5 DEF (1-999): Monster's ability to endure enemy physical attacks
	6 LOYALTY (0-100): Monster's loyalty to its trainer.  The lower it is, the more foolerys it will commit in battle. Average of "Spoil" and "Fear".
	7 LIFESPAN (0-600): # of weeks in a monster's life.  When it hits zero, monster dies.
	8 STRESS (0-100): How stressed out a monster is, the lower the better.  High stress results in runaways and reduced lifespan.
	9 FATIGUE (0-100): How fatigued a monster is, the lower the better.  High fatigue results in increased injury risk, increased training failure, and reduced lifespan.
	10 SPOIL (0-100): How spoiled a monster is.  Averaged to create Loyalty.  More likely to cheat in training, but less stressed.
	11 FORM (-100-100): How fat or skinny a monster is.  Being fat reduces damage taken, but also reduces evasion; being skinny does the opposite (increased damage taken, increased evasion).
	12 CLUTCH (-100-100): A random, hidden stat that increases with wins in critical condition (<15% health, maybe????).  The higher a monster's clutch, the better they will perform in critical condition.
	13 FEAR (0-100): Opposite of Spoil.  Averaged to create Loyalty.  Less likely to cheat in training, but could result in more stress.
	14 ORIGINAL LIFESPAN (1-600): uses this to calculate which lifeStage monster should be in.  Each lifeStage is 20% of a monster's life.
	*/
	private int[] stats = new int[15]; 

	//Stat Acquisition Array - how quickly LIF/POW/INT/SKI/SPD/DEF are raised, in that order.  Based on monster's breed. 0-4 scale, 5 being fastest.
	private int[] statAcq = new int[6];

	//Life Stage Array - 0-4 scale, 0 being "baby", 4 being "ancient".  Affects stat acquisition speeds in conjunction with StatAcq.  Only one is true at a time, starts with baby.
	private bool[] lifeStage = new bool[5];

	// Use this for initialization
	void Start () {
		stats [0] = 100; //lif
		stats [1] = 100; //pow
		stats [2] = 100; //int
		stats [3] = 100; //ski
		stats [4] = 100; //spd
		stats [5] = 100; //def
		stats [6] = (int)(((int)stats[10] + (int)stats[13]) / 2); //loyalty, avg of spoil and fear
		stats [7] = 20; //lifespan
		stats [8] = 0; //stress
		stats [9] = 0; //fatigue
		stats [10] = 100; //spoil
		stats [11] = 100; //form
		stats [12] = 100; //clutch
		stats [13] = 100; //fear
		stats [14] = 20; //OG lifespan

		statAcq [0] = 1;
		statAcq [1] = 2;
		statAcq [2] = 3;
		statAcq [3] = 4;
		statAcq [4] = 5;
		statAcq [5] = 1;

		lifeStage [0] = true;
		lifeStage [1] = false;
		lifeStage [2] = false;
		lifeStage [3] = false;
		lifeStage [4] = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			trainPow ();
		} else if (Input.GetKeyDown (KeyCode.L)) {
			trainLif ();
		}
	}

	//getters
	public int getLif(){
		return stats [0];
	}

	public int getPow(){
		return stats [1];
	}

	public int getInt(){
		return stats [2];
	}

	public int getSki(){
		return stats [3];
	}

	public int getSpd(){
		return stats [4];
	}

	public int getDef(){
		return stats [5];
	}

	public int getLoyalty(){
		return stats [6];
	}

	public int getLifespan(){
		return stats [7];
	}

	public int getStress(){
		return stats [8];
	}

	public int getFatigue(){
		return stats [9];
	}

	public int getSpoil(){
		return stats [10];
	}

	public int getForm(){
		return stats [11];
	}

	public int getClutch(){
		return stats [12];
	}

	public int getFear(){
		return stats [13];
	}

	public int getLifStatAcq(){
		return statAcq [0];
	}

	public int getPowStatAcq(){
		return statAcq [1];
	}


	public int getIntStatAcq(){
		return statAcq [2];
	}


	public int getSkiStatAcq(){
		return statAcq [3];
	}


	public int getSpdStatAcq(){
		return statAcq [4];
	}


	public int getDefStatAcq(){
		return statAcq [5];
	}
		
	public int getLifeStage(){
		int i = 0;

		while (!lifeStage [i]) {
			i++;
		}

		return i;
	}

	public int getOriginalLifespan(){
		return stats [14];
	}

	//setters
	public void setLif(int change){
		stats [0] += change;
	}

	public void setPow(int change){
		stats [1] += change;
	}

	public void setInt(int change){
		stats [2] += change;
	}

	public void setSki(int change){
		stats [3] += change;
	}

	public void setSpd(int change){
		stats [4] += change;
	}

	public void setDef(int change){
		stats [5] += change;
	}

	public void setLoyalty(int change){
		stats [6] += change;
	}

	public void setLifespan(int change){
		stats [7] += change;
	}

	public void setStress(int change){
		stats [8] += change;
	}

	public void setFatigue(int change){
		stats [9] += change;
	}

	public void setSpoil(int change){
		stats [10] += change;
	}

	public void setForm(int change){
		stats [11] += change;
	}

	public void setClutch(int change){
		stats [12] += change;
	}

	public void setFear(int change){
		stats [13] += change;
	}

	public void setLifStatAcq(int change){
		statAcq [0] += change;
	}


	public void setPowStatAcq(int change){
		stats [1] += change;
	}


	public void setIntStatAcq(int change){
		stats [2] += change;
	}


	public void setSkiStatAcq(int change){
		stats [3] += change;
	}


	public void setSpdStatAcq(int change){
		stats [4] += change;
	}


	public void setDefStatAcq(int change){
		stats [5] += change;
	}

	public void setLifeStage(int changeTo){
		//make all lifeStages false
		for (int i = 0; i < lifeStage.Length; i++) {
			lifeStage [i] = false;
		}

		//make the right one true
		lifeStage[changeTo] = true;
	}


	//Training methods!
	//These methods are based on lifestage - training gets better in the monster's prime, and worse on both ends.  Sine curve shit.
	public void trainLif(){
		Debug.Log ("lif was " + getLif ());

		if (lifeStage [0]) {
			setLif (Random.Range (1, 6));
		} else if (lifeStage [1]) {
			setLif (Random.Range (6, 11));
		} else if (lifeStage [2]) {
			setLif (Random.Range (11, 16));
		} else if (lifeStage [3]) {
			setLif (Random.Range (6, 11));
		} else {
			setLif (Random.Range (1, 6));
		}

		Debug.Log ("lif now is " + getLif ());

		setStress (10);
		setFatigue (10);

		advWeek ();
	}

	public void trainPow(){
		Debug.Log ("pow was " + getPow ());

		if (lifeStage [0]) {
			setPow (Random.Range (1, 6));
		} else if (lifeStage [1]) {
			setPow (Random.Range (6, 11));
		} else if (lifeStage [2]) {
			setPow (Random.Range (11, 16));
		} else if (lifeStage [3]) {
			setPow (Random.Range (6, 11));
		} else {
			setPow (Random.Range (1, 6));
		}

		Debug.Log ("pow now is " + getPow ());

		setStress (10);
		setFatigue (10);

		advWeek ();
	}

	public void trainInt(){
		Debug.Log ("Int was " + getInt ());

		if (lifeStage [0]) {
			setInt (Random.Range (1, 6));
		} else if (lifeStage [1]) {
			setInt (Random.Range (6, 11));
		} else if (lifeStage [2]) {
			setInt (Random.Range (11, 16));
		} else if (lifeStage [3]) {
			setInt (Random.Range (6, 11));
		} else {
			setInt (Random.Range (1, 6));
		}

		Debug.Log ("Int now is " + getInt ());

		setStress (10);
		setFatigue (10);

		advWeek ();
	}

	public void trainSki(){
		Debug.Log ("Ski was " + getSki ());

		if (lifeStage [0]) {
			setSki (Random.Range (1, 6));
		} else if (lifeStage [1]) {
			setSki (Random.Range (6, 11));
		} else if (lifeStage [2]) {
			setSki (Random.Range (11, 16));
		} else if (lifeStage [3]) {
			setSki (Random.Range (6, 11));
		} else {
			setSki (Random.Range (1, 6));
		}

		Debug.Log ("Ski now is " + getSki ());

		setStress (10);
		setFatigue (10);

		advWeek ();
	}

	public void trainSpd(){
		Debug.Log ("Spd was " + getSpd ());

		if (lifeStage [0]) {
			setSpd (Random.Range (1, 6));
		} else if (lifeStage [1]) {
			setSpd (Random.Range (6, 11));
		} else if (lifeStage [2]) {
			setSpd (Random.Range (11, 16));
		} else if (lifeStage [3]) {
			setSpd (Random.Range (6, 11));
		} else {
			setSpd (Random.Range (1, 6));
		}

		Debug.Log ("Spd now is " + getSpd ());

		setStress (10);
		setFatigue (10);

		advWeek ();
	}

	public void trainDef(){
		Debug.Log ("Def was " + getDef ());

		if (lifeStage [0]) {
			setDef (Random.Range (1, 6));
		} else if (lifeStage [1]) {
			setDef (Random.Range (6, 11));
		} else if (lifeStage [2]) {
			setDef (Random.Range (11, 16));
		} else if (lifeStage [3]) {
			setDef (Random.Range (6, 11));
		} else {
			setDef (Random.Range (1, 6));
		}

		Debug.Log ("Def now is " + getDef ());

		setStress (10);
		setFatigue (10);

		advWeek ();
	}

	//Resting method
	public void rest(){
		setStress (-20);
		setFatigue (-20);

		Debug.Log ("rested!  Stress now " + getStress () + " and fatigue now " + getFatigue ());

		advWeek ();
	}

	//advWeek() - sets lifeSpan and lifeStage appropriately for the monster's remaining lifespan. One week makes lifeSpan go down by 1 and lifeStage is calculated based on how many weeks are left
	public void advWeek(){
		setLifespan (-1);
		double lifeSpanRatio = ((double)getLifespan () / (double)getOriginalLifespan ());

		if (1 >= lifeSpanRatio && lifeSpanRatio >= .81) {
			setLifeStage (0);
		} else if (.8 >= lifeSpanRatio && lifeSpanRatio >= .61) {
			setLifeStage (1);
		} else if (.6 >= lifeSpanRatio && lifeSpanRatio >= .41) {
			setLifeStage (2);
		} else if (.4 >= lifeSpanRatio && lifeSpanRatio >= .21) {
			setLifeStage (3);
		} else if (.2 >= lifeSpanRatio && lifeSpanRatio >= 0.1) {
			setLifeStage (4);
		} else if (lifeSpanRatio == 0) {
			Debug.Log ("Dead!");
		}
	}
}
