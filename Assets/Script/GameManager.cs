using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1.0f;
public Score scoreDisplay; 

    private float lastCritterSpawn = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;
        if (Time.time >= lastCritterSpawn + critterSpawnFrequency)
        {
            //It is time

            //Choose a random critter to spawn
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            //Spwan the Critter
            GameObject spawnCritter = Instantiate(prefabToSpawn);

            //Get access to the critter script

            Critter critterScript = spawnCritter.GetComponent<Critter>();

            //Tell the critter script the score object

            critterScript.scoreDisplay = scoreDisplay;

            //Update the most recent critter spawn time to now

            lastCritterSpawn = Time.time;
        }
	}
}
