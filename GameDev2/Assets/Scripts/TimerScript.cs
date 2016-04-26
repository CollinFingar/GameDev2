using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class TimerScript : MonoBehaviour {

    public float timerLength = 5;
    public float timerStart = 0;
    public float timerEnd = 0;
    public float updateSpriteTime = 0;
    public int currentSpriteNum = 0;
	public int cycleNum = 0;

    public bool inProgress = false;

    public bool paused = false;
	public bool randomEventOnScreen = false;

    public Sprite[] sprites = new Sprite[8];

    public GameObject sprite;

	public GameObject contract;

    public GameObject[] planets = new GameObject[6];

	public Canvas RandomEventCanvas;

	public RandomEventScript rs;

	private int latestEventNum = 0;

	// Use this for initialization
	void Start () {
		startTimer(timerLength);
        sprite.GetComponent<SpriteRenderer>().sprite = sprites[0];
	}

	// Update is called once per frame
	void Update () {
        if (inProgress && !paused)
        {
            updateTimer();
        }
        else if (inProgress && paused) {
            timerStart += Time.deltaTime;
            timerEnd += Time.deltaTime;
            updateSpriteTime += Time.deltaTime;
        } else
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
			cycleNum += 1;
			DoRandomEvent ();
			GameObject.Find ("Faction1").GetComponent<FactionScript> ().destroyContracts ();
			GameObject.Find ("Faction2").GetComponent<FactionScript> ().destroyContracts ();
            inProgress = false;
            sendFinishToPlanets();
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
    }

    void sendFinishToPlanets() {
        for (int i = 0; i < planets.Length; i++) {
            PlanetScript ps = planets[i].GetComponent<PlanetScript>();
            ps.contractsFinish();
        }
    }

	void DoRandomEvent(){
		//compute whether or not to do random event and what type
		int r = Random.Range(0,7);

		if (r < 3) {
			latestEventNum = 0;
			rs.initEvent(0);
		} else if (r < 5) {
			latestEventNum = 1;
			rs.initEvent(1);
		} else if (r < 6) {
			latestEventNum = 2;
			rs.initEvent(2);
		} else if (r < 7) {
			latestEventNum = 3;
			rs.initEvent(3);
		}

		paused = true;
		randomEventOnScreen = true;
		RandomEventCanvas.gameObject.SetActive (true);
		
	}

	public void RemoveCanvasUnpause(){
		rs.doEvent(latestEventNum);
		paused = false;
		randomEventOnScreen = false;
		RandomEventCanvas.gameObject.SetActive (false);
	}
}
