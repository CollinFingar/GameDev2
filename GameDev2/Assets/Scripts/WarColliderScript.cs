using UnityEngine;
using System.Collections;

public class WarColliderScript : MonoBehaviour {

    public GameObject currentPlanet;
	public GameObject spaceLasers;
	public GameObject explosions;
    public string currentPlanetName;
    public bool onPlanet = false;
	public PlanetScript pData;
	Vector3 pos1;
	Vector3 pos2;
	public float factorA;

	public bool GAMEOVER = false;

	// Use this for initialization
	void Start () {
		pData = currentPlanet.GetComponent<PlanetScript>();
		pos1 = pData.leftNeighbor.transform.position;
		pos2 = currentPlanet.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		explosions.transform.position = currentPlanet.transform.position;
		if (spaceLasers.activeSelf && onPlanet) 
		{
			spaceLasers.SetActive (false);
			explosions.SetActive (true);

		} 
		else if (!onPlanet && !spaceLasers.activeSelf) 
		{
			spaceLasers.SetActive (true);
			explosions.SetActive (false);
		}
		if (transform.position.x > currentPlanet.transform.position.x && pData.rightNeighbor != null) 
		{ //assigns the next set of planets to use for lerping between
			pos1 = currentPlanet.transform.position;
			pos2 = pData.rightNeighbor.transform.position;
		} 
		else if (transform.position.x < currentPlanet.transform.position.x && pData.leftNeighbor != null)
			{
				pos1 = pData.leftNeighbor.transform.position;
				pos2 = currentPlanet.transform.position;
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
		if ((pData.leftNeighbor == null && transform.position.x < currentPlanet.transform.position.x)
			|| (pData.rightNeighbor == null && transform.position.x > currentPlanet.transform.position.x)) {
			GAMEOVER = true;
			//Application.LoadLevel (4);
		}
    }

    void OnTriggerStay2D(Collider2D coll) {
        currentPlanet = coll.gameObject;
		pData = currentPlanet.GetComponent<PlanetScript> ();
        currentPlanetName = coll.gameObject.GetComponent<PlanetScript>().planetName;
        Debug.Log(currentPlanetName);
    }
}
