using UnityEngine;
using System.Collections;

public class WarColliderScript : MonoBehaviour {

    public GameObject currentPlanet;
	public GameObject spaceLasers;
    public string currentPlanetName;
    public bool onPlanet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos1;
		Vector3 pos2;
		if (transform.position.x > currentPlanet.transform.position.x) {
			pos1 = currentPlanet.transform.position;
			pos2 = currentPlanet.GetComponent<PlanetScript> ().rightNeighbor.transform.position;
		} 
		else {
			pos1 = currentPlanet.GetComponent<PlanetScript> ().leftNeighbor.transform.position;
			pos2 = currentPlanet.transform.position;
		}
		spaceLasers.transform.position = new Vector3 (transform.position.x, Mathf.Lerp (pos1.y, pos2.y, (transform.position.x - pos1.y) / (pos2.y - pos1.y)),-1.0f);
	}

    void OnTriggerEnter2D(Collider2D coll) {
        onPlanet = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        onPlanet = false;
    }

    void OnTriggerStay2D(Collider2D coll) {
        currentPlanet = coll.gameObject;
        currentPlanetName = coll.gameObject.GetComponent<PlanetScript>().planetName;
        Debug.Log(currentPlanetName);
    }
}
