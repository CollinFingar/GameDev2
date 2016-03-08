using UnityEngine;
using System.Collections;

public class WarScript : MonoBehaviour {
    public GameObject Faction1;
    public GameObject Faction2;
	public int F1power;
	public int F2power;
    
    public float warStatus = .5f;

    public GameObject colors;
    public float farRightX = 6f;
    public float farLeftX = -6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		F1power = Faction1.GetComponent<FactionScript> ().power;
		F2power = Faction2.GetComponent<FactionScript> ().power;
		warStatus += ((F1power - F2power) * 0.00001f);

        colors.transform.position = new Vector3(farRightX * warStatus + farLeftX * (1 - warStatus), transform.position.y, transform.position.z);
	}
}
