using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public float timerLength = 5;
    public float timerStart = 0;
    public float timerEnd = 0;
    public float updateSpriteTime = 0;
    public int currentSpriteNum = 0;

    public bool inProgress = false;

    public Sprite[] sprites = new Sprite[8];

    public GameObject sprite;

	// Use this for initialization
	void Start () {
        startTimer(10);
        sprite.GetComponent<SpriteRenderer>().sprite = sprites[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (inProgress)
        {
            updateTimer();
        }
	}

    bool startTimer(float length)
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
        sprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteNum];
        Debug.Log("updating sprite: " + currentSpriteNum);
    }
}
