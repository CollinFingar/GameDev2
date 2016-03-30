using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;

public struct Supply{
	public int priority;
	public float quantity;
	public string type;
}

public class FactionScript : MonoBehaviour {
    public int faction = 0;
    public float money = 0;
	public float power = 0.0f;
	public Text armorText;
	public Text gunsText;
	public Text explosivesText;
	public Text shipsText;

	GameObject[] contracts = new GameObject[3];
	public GameObject contract;

	public Supply[] supplies = new Supply[6];
	string[] supplyTypes = {"Robots", "Guns", "Ammo",
		"Shields", "Ships", "Fuel"};

    // Use this for initialization
	void Start () {
		for (int i = 0; i < supplies.Length; i++) {
			supplies [i].type = supplyTypes [i];
			supplies [i].priority = i + 1;
			supplies [i].quantity = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < supplies.Length; i++) {
            if (supplies[i].type == "Shields") {
                armorText.text = "Shields: " + supplies[i].quantity.ToString();
            } else if (supplies[i].type == "Guns") {
                gunsText.text = "Guns: " + supplies[i].quantity.ToString();
            } else if (supplies[i].type == "Ships") {
                shipsText.text = "Ships: " + supplies[i].quantity.ToString();
            }

			power = (float)((supplies [0].quantity + supplies [4].quantity) * Math.Sqrt (supplies [1].quantity * Math.Sqrt (supplies [3].quantity)));
        }
		
		//gunsText.text = "Guns: " + supplies [1].quantity.ToString ();
		explosivesText.text = "Explosives: 100";
		//shipsText.text = "Ships: " + supplies [4].quantity.ToString ();
        
	}

	public void createContracts() {
		
		for (int i = 0; i < supplies.Length; i++) {
			supplies [i].priority = UnityEngine.Random.Range (1, 5);
		}

        //Random supply for now
        //Need to figure out how to sort supplies by priority

        Array.Sort(supplies, (x, y) => y.priority.CompareTo(x.priority));
        //supplies.OrderByDescending(x => x.priority);

        //int index;

		for (int i = 0; i < 3; i++) {
			GameObject temp = (GameObject)Instantiate (contract, new Vector3 ((faction - 1) * 14.9f + -7.45f, i * -2.5f + -6.5f, -1), Quaternion.identity);
			temp.GetComponent<ContractScript> ().Faction = faction;

            //index = UnityEngine.Random.Range (0, 5);
            temp.GetComponent<ContractScript>().faction = this.gameObject;
            temp.GetComponent<ContractScript> ().supply = supplies [i].type;
			temp.GetComponent<ContractScript> ().max = supplies [i].priority;
			temp.GetComponent<ContractScript> ().reward = supplies [i].priority * 10;

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
