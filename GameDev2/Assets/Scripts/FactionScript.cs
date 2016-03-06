using UnityEngine;
using System.Collections;

public class FactionScript : MonoBehaviour {

    public int faction = 0;

    public float money = 0;

    public float infantryPowerValue = 0;
    public float spacePowerValue = 0;
    public int[] infantryResources = new int[5];
    public int[] spaceResources = new int[5];

	GameObject[] contracts = new GameObject[3];
	public GameObject contract;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void createContracts() {
		for (int i = 0; i < 3; i++) 
		{
			GameObject tmp = (GameObject)Instantiate (contract, new Vector3 ((faction-1) * 14.9f + -7.45f, i * -2.5f + -6.5f,-1),Quaternion.identity);
			tmp.GetComponent<ContractScript> ().Faction = faction;
			contracts[i] = tmp; //add Contract to array
		}
	}

	public void destroyContracts() {
		for (int i = 0; i < 3; i++) 
		{
			contracts [i].GetComponent<ContractScript> ().moveTime = 50;
		}
	}
}
