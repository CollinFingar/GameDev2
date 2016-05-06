using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;
using Random=UnityEngine.Random;

public struct Supply{
	public string type;
	public int quantity;
	public int power;
	public int[] cost;
	public int reward;
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
	public GameObject timer;
	
	public Supply[] supplies = new Supply[7];
	string[] supplyTypes = {"Ammo", "Fuel", "Robots", "Plasma", "Blasters", "Artillery", "Ships"};
	int[,] supplyCosts = {{10,0,0}, {0,10,0}, {20,10,0}, {0,0,10}, {20,0,10}, {20,10,10}, {25,20,10}};
	int[] supplyPowers = {100, 300, 900, 1250, 2000, 3000, 4000};
	int[] supplyRewards = {175, 330, 570, 625, 790, 675, 600};
	
    // Use this for initialization
	void Start () {
		int i;
		for (i = 0; i < supplies.Length; i++) {
			supplies [i].type = supplyTypes [i];
			supplies [i].quantity = 0;
			supplies [i].power = supplyPowers[i];
			supplies [i].cost = new int[] {supplyCosts[i,0], supplyCosts[i,1], supplyCosts[i,2]};
			supplies [i].reward = supplyRewards[i];
		}
		power = 0;
	}
	
	// Update is called once per frame
	void Update () { 
	
	}

	public void createContracts() {

		int index = 0;
		
		for (int i = 0; i < 3; i++) {
			GameObject temp = (GameObject)Instantiate (contract, new Vector3 ((faction - 1) * 14.9f + -7.45f, i * -2.5f + -6.5f, -1), Quaternion.identity);
			ContractScript newContract = temp.GetComponent<ContractScript> ();
			newContract.Faction = faction;
			newContract.faction = this.gameObject;
            
			index = Random.Range(0,supplies.Length);
			
			//Rework these values
			newContract.supply = supplies[index].type;
			newContract.metalCost = supplies[index].cost[0];
			newContract.fuelCost = supplies[index].cost[1];
			newContract.plasmaCost = supplies[index].cost[2];
			newContract.reward = supplies[index].reward;
			
			newContract.max = (int)Math.Round((float)timer.GetComponent<TimerScript> ().cycleNum / 3.0f) + Random.Range(1,3);
			newContract.powerIndex = index; //will set index for use in ContractScripts contractStrengths array

			contracts [i] = temp;
		}
	}

	public void destroyContracts() {
		for (int i = 0; i < 3; i++) 
		{
			contracts [i].GetComponent<ContractScript> ().moveTime = 50;
		}
	}
	
	public void addToPower(int index, int amount){
		power += supplies[index].power * amount;
		supplies[index].quantity += amount;
	}
}
