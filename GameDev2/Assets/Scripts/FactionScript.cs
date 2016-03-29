﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;


public struct Supply{
	public int priority;
	public int quantity;
	public string type;
}

public class FactionScript : MonoBehaviour {
    public int faction = 0;
    public float money = 0;
	public int power = 0;
	public Text armorText;
	public Text gunsText;
	public Text explosivesText;
	public Text shipsText;

	GameObject[] contracts = new GameObject[3];
	public GameObject contract;

	Supply[] supplies = new Supply[6];
	string[] supplyTypes = {"Robots", "Guns", "Ammo",
		"Shields", "Ships", "Fuel"};

    // Use this for initialization
	void Start () {
		for (int i = 0; i < supplies.Length; i++) {
			supplies [i].type = supplyTypes [i];
			supplies [i].priority = i + 1;
			supplies [i].quantity = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		armorText.text = "Armor: " + supplies [3].quantity.ToString ();
		gunsText.text = "Guns: " + supplies [1].quantity.ToString ();
		explosivesText.text = "Explosives: 100";
		shipsText.text = "Ships: " + supplies [4].quantity.ToString ();

	}

	public void createContracts() {
		
		for (int i = 0; i < supplies.Length; i++) {
			supplies [i].priority = Random.Range (1, 5);
		}

		//Random supply for now
		//Need to figure out how to sort supplies by priority
		int index;

		for (int i = 0; i < 3; i++) {
			GameObject temp = (GameObject)Instantiate (contract, new Vector3 ((faction - 1) * 14.9f + -7.45f, i * -2.5f + -6.5f, -1), Quaternion.identity);
			temp.GetComponent<ContractScript> ().Faction = faction;

			index = Random.Range (0, 5);

			temp.GetComponent<ContractScript> ().supply = supplies [index].type;
			temp.GetComponent<ContractScript> ().max = supplies [index].priority;

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
