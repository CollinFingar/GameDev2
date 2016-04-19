using UnityEngine;
using System.Collections;

public class WarColliderScript : MonoBehaviour {

    public GameObject currentPlanet;
	public GameObject spaceLasers;
    public string currentPlanetName;
    public bool onPlanet = false;
	PlanetScript pData;
	Vector3 pos1;
	Vector3 pos2;
	public float factorA; 

	// Use this for initialization
	void Start () {
		pData = currentPlanet.GetComponent<PlanetScript>();
		pos1 = pData.leftNeighbor.transform.position;
		pos2 = currentPlanet.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (pData.rightNeighbor != null && transform.position.x > currentPlanet.transform.position.x) 
		{ //assigns the next set of planets to use for lerping between
			currentPlanet = pData.rightNeighbor;
			pData = currentPlanet.GetComponent<PlanetScript> ();
			pos1 = pData.leftNeighbor.transform.position;
			pos2 = currentPlanet.transform.position;
		} 
		else {
			if (pData.leftNeighbor != null && transform.position.x < pData.leftNeighbor.transform.position.x) 
			{
				currentPlanet = pData.leftNeighbor;
				pData = currentPlanet.GetComponent<PlanetScript> ();
				pos1 = pData.leftNeighbor.transform.position;
				pos2 = currentPlanet.transform.position;
			}
		}
		factorA = (transform.position.x - pos1.x) / (pos2.x - pos1.x);
		spaceLasers.transform.position = new Vector3 (transform.position.x, Mathf.Lerp (pos1.y, pos2.y, factorA),-1.0f);
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
