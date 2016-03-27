using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FactionScript : MonoBehaviour {

    public int faction = 0;
    public float money = 0;

	//Actual Supplies
	public int robots = 0;
	public int humans = 0;
	/*
	public int totalSoldiers = 0;
	public int guns = 0;
	public int ammo = 0;
	public int armor = 0;
	public int explosives = 0;
	public int ships = 0;
	public int fuel = 0;
	public int hazardSuits = 0;
	public int artillery = 0;
	public int medicine = 0;
	public int element0 = 0;
	*/
	//#######################//

	//Supply need
	public int [] priorities = new int [] {0,0,0,0,0,0,0,0,0,0,0};
	public int [] quantity = new int[] {0,0,0,0,0,0,0,0,0,0,0};
	public string [] supplies = new string[] {"Soldiers", "Guns", "Ammo",
		"Armor", "Explosives", "Ships", "Fuel", "Suits", "Artillery", "Medicine", "Element0"};
	public string [] selectedContract = new string[3];
	public int [] selectedContractPri = new int[] {0,0,0};
	/*
	public int soldierNeed = 0;
	public int gunNeed = 0;
	public int ammoNeed = 0;
	public int armorNeed = 0;
	public int explosivesNeed = 0;
	public int shipsNeed = 0;
	public int fuelNeed = 0;
	public int suitNeed = 0;
	public int artilleryNeed = 0;
	public int medNeed = 0;
	public int elementNeed = 0;
	*/
	//#######################//

	public int power = 0;
	public Text armorText;
	public Text gunsText;
	public Text explosivesText;
	public Text shipsText;

	GameObject[] contracts = new GameObject[3];
	public GameObject contract;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		armorText.text = "Armor: " + quantity[3].ToString ();
		gunsText.text = "Guns: " + quantity[1].ToString ();
		explosivesText.text = "Explosives: " + quantity[4].ToString ();
		shipsText.text = "Ships: " + quantity[5].ToString ();

	}

	public void prioritizeSupply(){

		for (int i = 0; i < priorities.Length; i++) {
			priorities [i] = i + 1;

			for(int j = 0; j < selectedContract.Length; j++){
				if (priorities [i] > selectedContractPri [j]) {
					selectedContract [j] = supplies [i];
					selectedContractPri [j] = priorities [i];
				}
			}


		}
	}

	public void createContracts() {

		prioritizeSupply ();

		for (int i = 0; i < selectedContract.Length; i++) {
			GameObject temp = (GameObject)Instantiate (contract, new Vector3 ((faction - 1) * 14.9f + -7.45f, i * -2.5f + -6.5f, -1), Quaternion.identity);
			temp.GetComponent<ContractScript> ().Faction = faction;
			temp.GetComponent<ContractScript> ().supply = selectedContract [i];

			contracts [i] = temp;

			/*
			    public string supply;
				public int max = 0;
				public int reward = 0;
				public int filled = 0;
				public bool complete = false;
			*/
		}
	}

	public void destroyContracts() {
		for (int i = 0; i < 3; i++) 
		{
			contracts [i].GetComponent<ContractScript> ().moveTime = 50;
		}
	}
}
