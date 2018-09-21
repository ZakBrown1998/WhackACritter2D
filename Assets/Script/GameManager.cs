﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

public List<GameObject> critterPrefabs;
public float critterSpawnFrequency = 1.0f;
public Score scoreDisplay;
public Timer timer;
    public SpriteRenderer button;

    private float lastCritterSpawn = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;
        if (Time.time >= nextSpawnTime && timer.IsTimerRunning()==true)
        {
            //It is time

            //Choose a random critter to spawn
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            //Spwan the Critter
            GameObject spawnCritter = Instantiate(prefabToSpawn);

            //Get access to the critter script

            Critter critterScript = spawnCritter.GetComponent<Critter>();

            //Tell the critter script the score object and the timer object

            critterScript.scoreDisplay = scoreDisplay;

            critterScript.timer = timer;

            //Update the most recent critter spawn time to now

            lastCritterSpawn = Time.time;
        }
        //update button visibility
        if (timer.IsTimerRunning() == true)
        {
            button.enabled = false;
        }
        else //If game is not running
        {
            button.enabled = true;
        }
	}
    //Did they click the button?
    private void OnMouseDown()
    {
        if (timer.IsTimerRunning() == false)
        {
            //Start a new game
            timer.StartTimer();
            scoreDisplay.ResetScore();
        }
    }
}
