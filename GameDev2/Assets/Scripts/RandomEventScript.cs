using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using Random=UnityEngine.Random;

public struct Event{
	public string title;
	public string body;
}

public class RandomEventScript : MonoBehaviour {
	
	public Text title;
	public Text body;
	
	public GameObject F1;
	public Text F1name;
	public GameObject F2;
	public Text F2name;
	public int Faction;
	
	public Event[] events = new Event[6];
	public Event E1;

	public WarScript ws;
	public PlayerScript ps;
	
	// Use this for initialization
	void Start () {
		int i = 0;

		E1.title = "Call to Arms!";
		E1.body = " conducts a large propaganda campaign to recruit a large force of new soldiers.";
		events[i] = E1;
		i++;

		E1.title = "Backdoor Deals!";
		E1.body = " bought a large shipment of fuel and plasma from another dealer!";
		events[i] = E1;
		i++;

		E1.title = "Holiday Week!";
		E1.body = "There is peace in recognition of this wonderous week.";
		events[i] = E1;
		i++;

		E1.title = "Embargo!";
		E1.body = "All planets in the system have placed an embargo on weapon, warship, and toilet paper manufacturers.";
		events[i] = E1;
		i++;
		
		E1.title = "Hot Lead";
		E1.body = "Guns are more powerful this cycle.";
		events[i] = E1;
		i++;
		
		E1.title = "The Speed of Light";
		E1.body = "Ships are more powerful this cycle.";
		events[i] = E1;
		i++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void initEvent(int num){
		Faction = Random.Range(0,2);
		title.text = events[num].title;

		if (num < 2) {
			if (Faction == 0) {
				body.text = F1name.text + events [num].body;
			} else {
				body.text = F2name.text + events [num].body;
			}
		} else {
			body.text = events [num].body;
		}

		
		
	}
	
	public void doEvent(int num){
		
		if (num == 0) {
			//Call to arms
			if (Faction == 0) {
				F1.GetComponent<FactionScript> ().addToPower(2, 1);
			} else {
				F2.GetComponent<FactionScript> ().addToPower(2, 1);
			}
			
		} else if (num == 1) {
			//Backdoor Deals
			int r = Random.Range(0,3);
			if (r == 0) {
				if (Faction == 0) {
					F1.GetComponent<FactionScript> ().addToPower(0, 2);
				} else {
					F2.GetComponent<FactionScript> ().addToPower(0, 2);
				}
			} else if (r == 1) {
				if (Faction == 0) {
					F1.GetComponent<FactionScript> ().addToPower(1, 2);
				} else {
					F2.GetComponent<FactionScript> ().addToPower(1, 2);
				}
			} else {
				if (Faction == 0) {
					F1.GetComponent<FactionScript> ().addToPower(3, 2);
				} else {
					F2.GetComponent<FactionScript> ().addToPower(3, 2);
				}
			}
			
		} else if (num == 2) {
			//GM Week
			ws.StartPeaceWeek();
			
		} else if (num == 3) {
			//Embargo
			ps.StartEmbargoWeek();
		
		} else if (num == 4) {
			//Hot Lead
			F1.GetComponent<FactionScript> ().supplies[4].power += 500;
			F2.GetComponent<FactionScript> ().supplies[4].power += 500;
			ws.StartHotLead();
		
		} else if(num == 5) {
			//The Speed of Sound
			F1.GetComponent<FactionScript> ().supplies[6].power += 1500;
			F2.GetComponent<FactionScript> ().supplies[6].power += 1500;
			ws.StartSpeed();
		}
		
	}
	
}
