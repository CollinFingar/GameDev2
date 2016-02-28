using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public float timerLength = 5;
    public float timerStart = 0;
    public float timerEnd = 0;
    public float updateSpriteTime = 0;
    public int currentSpriteNum = 0;

    public bool inProgress = false;

	// Use this for initialization
	void Start () {
        startTime(10);
	}
	
	// Update is called once per frame
	void Update () {
        if (inProgress)
        {
            updateTimer();
        }
	}

    bool startTime(float length)
    {
        if (inProgress)
        {
            return false;
        }
        currentSpriteNum = 0;
        inProgress = true;
        timerLength = length;
        timerStart = Time.time;
        timerEnd = timerStart + timerLength;
        updateSpriteTime = Time.time + timerLength / 8;
        return true;
    }

    void updateTimer()
    {
        float time = Time.time;
        if(time >= timerEnd)
        {
            currentSpriteNum++;
            updateSprite();
            inProgress = false;
        }
        else
        {
            if(time > updateSpriteTime)
            {
                currentSpriteNum++;
                updateSprite();
                updateSpriteTime += timerLength / 8;

            }
        }
    }

    void updateSprite()
    {
        Debug.Log("updating sprite: " + currentSpriteNum);
    }
}
