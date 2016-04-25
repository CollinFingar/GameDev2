using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;

public struct Supply{
	public string type;
	public int quantity;
	public int power;
	public int[] cost;
}

public class FactionScript : MonoBehaviour {
    public int faction = 0;
	public int power = 0;
	public Text armorText;
	public Text gunsText;
	public Text explosivesText;
	public Text shipsText;

	GameObject[] contracts = new GameObject[3];
	public GameObject contract;

	public Supply[] supplies = new Supply[6];
	string[] supplyTypes = {"Ammo", "Fuel", "Robots", "Plasma", "Blasters", "Artillery", "Ships"};
	int[,] supplyCosts = {{10,0,0}, {0,10,0}, {20,10,0}, {0,0,10}, {20,0,10}, {20,10,10}, {25,20,10}};
	int[] supplyPowers = {100, 300, 900, 1250, 2000, 3000, 4000};
	
    // Use this for initialization
	void Start () {
		int i;
		for (i = 0; i < supplies.Length; i++) {
			supplies [i].type = supplyTypes [i];
			supplies [i].quantity = 0;
			supplies [i].power = supplyPowers[i];
			supplies [i].cost = new int[] {supplyCosts[i,0], supplyCosts[i,1], supplyCosts[i,2]};
		}
	}
	
	// Update is called once per frame
	void Update () {   
	}

	public void createContracts() {

		for (int i = 0; i < 3; i++) {
			GameObject temp = (GameObject)Instantiate (contract, new Vector3 ((faction - 1) * 14.9f + -7.45f, i * -2.5f + -6.5f, -1), Quaternion.identity);
			temp.GetComponent<ContractScript> ().Faction = faction;
            temp.GetComponent<ContractScript>().faction = this.gameObject;
            
			
			//Rework these values
			temp.GetComponent<ContractScript> ().supply = "Blasters";
			temp.GetComponent<ContractScript> ().metalCost = 2;
			temp.GetComponent<ContractScript> ().fuelCost = 2;
			temp.GetComponent<ContractScript> ().plasmaCost = 2;
			temp.GetComponent<ContractScript> ().max = 5;
			temp.GetComponent<ContractScript> ().reward = 100;

			contracts [i] = temp;
		}
	}

	public void destroyContracts() {
		for (int i = 0; i < 3; i++) 
		{
			contracts [i].GetComponent<ContractScript> ().moveTime = 50;
		}
	}
}
