﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    //Display Visual Timer
    public TextMesh displayText;

    //Starting time for the timer
    public float timerDuration;

    //Current Seconds Remaining on the timer
    private float timeRemaining = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//Only access if timer is running
    if (IsTimerRunning())
        {
            //Time is running, so process

            timeRemaining = timeRemaining - Time.deltaTime;

            //Check if we have now run out of time
            if(timeRemaining <=0)
            {
                StopTimer();
            }
            
            //Update the visual display
            displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
		
	}
    //Starts the timer counting
    public void StartTimer()
    {
        timeRemaining = timerDuration;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    //Stop the timer from counting down
    public void StopTimer()
    {
        timeRemaining = 0;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }
    //Is the timer currently running?

    public bool IsTimerRunning()
    {
        if (timeRemaining !=0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    }

