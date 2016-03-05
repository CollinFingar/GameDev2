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
		startTimer(timerLength);
        sprite.GetComponent<SpriteRenderer>().sprite = sprites[0];
	}

	// Update is called once per frame
	void Update () {
		if (inProgress) 
		{
			updateTimer ();
		} 
		else 
		{
			startTimer (timerLength);
		}
	}

    bool startTimer(float length)
    {
        if (inProgress)
        {
            return false;
        }
        currentSpriteNum = 0;
		sprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteNum];
        inProgress = true;
        timerLength = length;
        timerStart = Time.time;
        timerEnd = timerStart + timerLength;
        updateSpriteTime = Time.time + timerLength / 9;
		//create new contracts
		GameObject.Find ("Faction1").GetComponent<FactionScript> ().createContracts ();
		GameObject.Find ("Faction2").GetComponent<FactionScript> ().createContracts ();
        return true;
    }

    void updateTimer()
    {
        float time = Time.time;
        if(time >= timerEnd)
        {
			GameObject.Find ("Faction1").GetComponent<FactionScript> ().destroyContracts ();
			GameObject.Find ("Faction2").GetComponent<FactionScript> ().destroyContracts ();
            inProgress = false;
        }
        else
        {
            if(time > updateSpriteTime)
            {
                currentSpriteNum++;
                updateSprite();
                updateSpriteTime += timerLength / 9;

            }
        }
    }

    void updateSprite()
    {
        sprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteNum];
        Debug.Log("updating sprite: " + currentSpriteNum);
    }
}
