using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarScript : MonoBehaviour {
    public GameObject Faction1;
    public GameObject Faction2;
	public float F1power;
	public float F2power;
    
    public float warStatus = .5f;

    public GameObject colors;
    public float farRightX = 6f;
    public float farLeftX = -6f;

    public GameObject collider;
    private WarColliderScript wcs;
    public GameObject[] planets = new GameObject[6];
    private bool warOnPlanet = false;

    public long deaths = 0;
    public Text deathCounter;

	public TimerScript timer;

	private int peaceWeekEnd = 0;
	private bool peaceWeek = false;

	// Use this for initialization
	void Start () {
        wcs = collider.GetComponent<WarColliderScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!timer.randomEventOnScreen) {
			if (wcs.onPlanet && wcs.pData.population > 5000) {
				long r = Random.Range (3000, 5000);

				deaths += r;
				wcs.pData.population -= r;
				Debug.Log (wcs.pData.planetName);
			} else if (wcs.onPlanet && wcs.pData.population <= 5000) {
				long r = wcs.pData.population;
				deaths += r;
				wcs.pData.population = (long)0;
			}
				
			deathCounter.text = "DEATHS: " + deaths.ToString();

			F1power = (float)Faction1.GetComponent<FactionScript> ().power;
			F2power = (float)Faction2.GetComponent<FactionScript> ().power;

			Debug.Log(F1power);
			Debug.Log(F2power);

			//NEW WAR ALGORITHM HERE//

			if(F1power - F2power != 0){
				warStatus += (F1power - F2power) * 0.0000001f;
			}

			colors.transform.position = new Vector3(farRightX * warStatus + farLeftX * (1 - warStatus), transform.position.y, transform.position.z);
			collider.transform.position = new Vector3(farRightX * warStatus + farLeftX * (1 - warStatus), transform.position.y, transform.position.z);
		}
		if (peaceWeek && timer.cycleNum >= peaceWeekEnd) {
			peaceWeek = false;
		}
    }


	public void StartPeaceWeek(){
		peaceWeek = true;
		peaceWeekEnd = timer.cycleNum + 1;
	}

    
}
