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
	
	public Event[] events = new Event[1];
	public Event E1;
	
	// Use this for initialization
	void Start () {
		
		E1.title = "Call to Arms!";
		E1.body = " conducts a large propaganda campaign to recruit a large force of new soldiers.";
		
		events[0] = E1;
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
		
		if(num == 0){
			if(Faction == 0){
				F1.GetComponent<FactionScript> ().supplies[2].quantity += 1;
			}else{
				F2.GetComponent<FactionScript> ().supplies[2].quantity += 1;
			}
		}
		
	}
	
}
