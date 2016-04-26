using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public struct Event{
	public string title;
	public string body;
	public int eventNum;
}

public class RandomEventScript : MonoBehaviour {
	
	public Text title;
	public Text body;
	
	public GameObject F1;
	public GameObject F2;
	
	public Event E;
	
	// Use this for initialization
	void Start () {
		
		E.title = "Title";
		E.body = "Body body body body body";
		E.eventNum = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void initEvent(int num){
		if(num == E.eventNum){
			title.text = E.title;
			body.text = E.body;
		}
	}
	
	public void doEvent(int num){
		
		if(num == E.eventNum){
			F1.GetComponent<FactionScript> ().supplies[0].quantity += 1;
		}
		
	}
	
}
