using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FactionScript : MonoBehaviour {

    public int faction = 0;

    public float money = 0;

	public int armor = 0;
	public int guns = 0;
	public int explosives = 0;
	public int ships = 0;

	public int power = 0;

	public Text armorText;
	public Text gunsText;
	public Text explosivesText;
	public Text shipsText;

	GameObject[] contracts = new GameObject[3];
	public GameObject contract;

	int[,] contractPool = new int[8, 4] { 
											{ 0, 1, 10, 3 }, 
											{ 1, 1, 10, 3 }, 
											{ 2, 1, 10, 3 }, 
											{ 3, 1, 15, 5 },

											{ 0, 5, 60, 5 }, 
											{ 1, 5, 60, 5 }, 
											{ 2, 5, 60, 5 }, 
											{ 3, 3, 100, 7 } 
																};

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		armorText.text = "Armor: " + armor.ToString ();
		gunsText.text = "Guns: " + guns.ToString ();
		explosivesText.text = "Explosives: " + explosives.ToString ();
		shipsText.text = "Ships: " + ships.ToString ();

		if (contract.GetComponent<ContractScript> ().completed == true) {
			power += contract.GetComponent<ContractScript> ().PowerReward;
		}

	}

	public void createContracts() {

		int randCon = 0;
		for (int i = 0; i < 3; i++) 
		{
			randCon = Random.Range (0, 8);
			GameObject tmp = (GameObject)Instantiate (contract, new Vector3 ((faction-1) * 14.9f + -7.45f, i * -2.5f + -6.5f,-1),Quaternion.identity);
			tmp.GetComponent<ContractScript> ().Faction = faction;

			tmp.GetComponent<ContractScript> ().CostType = contractPool [randCon, 0];
			tmp.GetComponent<ContractScript> ().CostAmount = contractPool [randCon, 1];
			tmp.GetComponent<ContractScript> ().RewardAmount = contractPool [randCon, 2];
			tmp.GetComponent<ContractScript> ().PowerReward = contractPool [randCon, 3];

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
