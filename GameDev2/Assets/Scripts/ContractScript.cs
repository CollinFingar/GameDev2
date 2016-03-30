﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ContractScript : MonoBehaviour {

	//Properties
	public string supply;
	public int max = 5;
	public int reward = 0;
	public int filled = 0;
	public bool complete = false;
	//#######################//

	//Cost
	public int fuelCost = 0;
	public int metalCost = 0;
	public int plasmaCost = 0;
	//########################//

	//Contract motion
	public int Faction = 0;
	public float moveTime = 0;
	public int moveType = 0; //type of movement (0 = creation, 1 = expire)
	Text desc;
	//######################################################################//

	public GameObject player;
	public bool giveMoney = true;

    public GameObject faction;

	// Use this for initialization
	void Start () {

		if (supply == "Robots") {
			metalCost = 5;
		}

		if (supply == "Guns") {
			metalCost = 3;
			plasmaCost = 2;
		}

		if (supply == "Ships") {
			fuelCost = 5;
			metalCost = 5;
		}

		if (supply == "Shields") {
			fuelCost = 5;
			plasmaCost = 3;
		}

		if (supply == "Ammo") {
			metalCost = 2;
		}

		if (supply == "Fuel") {
			fuelCost = 5;
		}


		player = GameObject.FindGameObjectWithTag ("Player");
		desc = this.gameObject.GetComponentInChildren<Text> ();
		desc.text = supply+"\n"+filled.ToString()+"/"+max.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveTime > 0) 
		{
			moveContract ();
		}
		desc.text = supply+"\n"+filled.ToString()+"/"+max.ToString();
	}

	void moveContract()
	{
		if (moveType == 0) //Move on Screen/Create
		{
			float newY = this.transform.position.y + (moveTime/50)*.34f;
			this.transform.position = new Vector3(this.transform.position.x,newY,this.transform.position.z);
			moveTime--;
			if (moveTime == 0) 
			{
				moveType = 1;
			}
		}
		else if (moveType == 1)
		{
			float newX = this.transform.position.x - (1 - 2*(Faction-1)) * (50/moveTime *.17f);
			this.transform.position = new Vector3(newX,this.transform.position.y,this.transform.position.z);
			moveTime--;

			if(giveMoney){
				player.GetComponent<PlayerScript> ().money += reward;
                GiveFactionResources();
				giveMoney = false;

			}


			if (moveTime == 0) 
			{
				Debug.Log ("Goodbye World!");
				Destroy (this.gameObject);
			}

		}
	}

    void GiveFactionResources() {
        FactionScript fs = faction.GetComponent<FactionScript>();
        if (supply == "Robots")
        {
            fs.supplies[0].quantity += filled;
        }

        if (supply == "Guns")
        {
            fs.supplies[1].quantity += filled;
        }

        if (supply == "Ships")
        {
            fs.supplies[2].quantity += filled;
        }

        if (supply == "Shields")
        {
            fs.supplies[3].quantity += filled;
        }

        if (supply == "Ammo")
        {
            fs.supplies[4].quantity += filled;
        }

        if (supply == "Fuel")
        {
            fs.supplies[5].quantity += filled;
        }
    }

    void OnMouseEnter()
    {
		if (complete == false) {
			SetHoverColor ();
		}
    }

    void OnMouseExit()
    {
		if (complete == false) {
			ResetColor ();
		}
    }

	void SetCompletedColor(){
		GetComponent<SpriteRenderer>().color = Color.green;
	}

    void SetHoverColor()
    {
        //==================================
        //Change to Alternative Button Looks
        //==================================
        GetComponent<SpriteRenderer>().color = new Color(.8f, .8f, .8f, 1f);
    }

    void ResetColor()
    {
        //===============================
        //Change to Original Button Looks
        //===============================
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseUp()
    {
		if (complete == false) {

			if (player.GetComponent<PlayerScript> ().resourceFuel >= fuelCost && player.GetComponent<PlayerScript> ().resourceMetal >= metalCost && player.GetComponent<PlayerScript> ().resourcePlasma >= plasmaCost) {

				player.GetComponent<PlayerScript> ().resourceFuel -= fuelCost;
				player.GetComponent<PlayerScript> ().resourceMetal -= metalCost;
				player.GetComponent<PlayerScript> ().resourcePlasma -= plasmaCost;

				filled += 1;
				if (filled == max) {
					complete = true;
					SetCompletedColor ();
				}
			}
		}
    }


}
