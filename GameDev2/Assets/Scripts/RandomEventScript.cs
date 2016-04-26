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
	
	public Event[] events = new Event[4];
	public Event E1;

	public WarScript ws;
	
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

		E1.title = "GM Week!";
		E1.body = " offered an olive branch of peace in recognition of this wonderous week.";
		events[i] = E1;
		i++;

		E1.title = "Embargo!";
		E1.body = "All planets in the system have placed an embargo on weapon, warship, and toilet paper manufacturers.";
		events[i] = E1;
		i++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void initEvent(int num){
		Faction = Random.Range(0,2);
		title.text = events[num].title;
		
		if(Faction == 0){
			body.text = F1name.text+events[num].body;
		}else{
			body.text = F2name.text+events[num].body;
		}
		
		
	}
	
	public void doEvent(int num){
		
		if (num == 0) {
			//Call to arms
			if (Faction == 0) {
				F1.GetComponent<FactionScript> ().supplies [2].quantity += 1;
			} else {
				F2.GetComponent<FactionScript> ().supplies [2].quantity += 1;
			}
		} else if (num == 1) {
			//Backdoor Deals
			int r = Random.Range(0,3);
			if (r == 0) {
				if (Faction == 0) {
					F1.GetComponent<FactionScript> ().supplies [0].quantity += 2;
				} else {
					F2.GetComponent<FactionScript> ().supplies [0].quantity += 2;
				}
			} else if (r == 1) {
				if (Faction == 0) {
					F1.GetComponent<FactionScript> ().supplies [1].quantity += 2;
				} else {
					F2.GetComponent<FactionScript> ().supplies [1].quantity += 2;
				}
			} else {
				if (Faction == 0) {
					F1.GetComponent<FactionScript> ().supplies [3].quantity += 2;
				} else {
					F2.GetComponent<FactionScript> ().supplies [3].quantity += 2;
				}
			}
		} else if (num == 2) {
			//GM Week
			ws.StartPeaceWeek();
		} else if (num == 3) {
			//Embargo

		}
		
	}
	
}
