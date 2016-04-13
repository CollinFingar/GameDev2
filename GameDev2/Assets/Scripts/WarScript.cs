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

    public int deaths = 0;
    public Text deathCounter;

	// Use this for initialization
	void Start () {
        wcs = collider.GetComponent<WarColliderScript>();
	}
	
	// Update is called once per frame
	void Update () {
        deaths += Random.Range(80, 140);
        deathCounter.text = "DEATHS: " + deaths.ToString();


        warOnPlanet = wcs.onPlanet;
        if (warOnPlanet) {
            //Do ground war thing here
        } else {
            //Do space war here
        }

		F1power = Faction1.GetComponent<FactionScript> ().power;
		F2power = Faction2.GetComponent<FactionScript> ().power;

		if(F1power > F2power){
			F1power = F1power - Faction2.GetComponent<FactionScript> ().supplies[3].quantity;
			if (F1power < 0) {
				warStatus += 0;
			} else {
				warStatus += F1power * 0.00001f;
			}

		}else{
			F2power = F2power - Faction1.GetComponent<FactionScript> ().supplies[3].quantity;
			if (F2power < 0) {
				warStatus += 0;
			} else {
				warStatus -= F2power * 0.00001f;
			}
		}

        colors.transform.position = new Vector3(farRightX * warStatus + farLeftX * (1 - warStatus), transform.position.y, transform.position.z);
        collider.transform.position = new Vector3(farRightX * warStatus + farLeftX * (1 - warStatus), transform.position.y, transform.position.z);
    }

    
}
