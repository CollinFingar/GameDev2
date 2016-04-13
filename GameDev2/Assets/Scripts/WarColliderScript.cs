using UnityEngine;
using System.Collections;

public class WarColliderScript : MonoBehaviour {

    public string currentPlanetName;
    public bool onPlanet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        onPlanet = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        onPlanet = false;
    }

    void OnTriggerStay2D(Collider2D coll) {
        //Debug.Log(coll.gameObject.GetComponent<PlanetScript>().planetName);
        currentPlanetName = coll.gameObject.GetComponent<PlanetScript>().planetName;
    }
}
