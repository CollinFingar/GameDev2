using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContractScript : MonoBehaviour {

	//Properties
	public string supply;
	public int max = 5;
	public int reward = 0;
	public int filled = 0;
	public bool complete = false;
	//#######################//

	//Contract motion
	public int Faction = 0;
	public float moveTime = 0;
	public int moveType = 0; //type of movement (0 = creation, 1 = expire)
	Text desc;
	//######################################################################//

	public GameObject player;

	// Use this for initialization
	void Start () {
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

			if (moveTime == 0) 
			{
				Debug.Log ("Goodbye World!");
				Destroy (this.gameObject);
			}

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

    void OnMouseDown()
    {
        //================
        //Do Whatever Here
        //================
		if (complete == false) {
			
		}
        
    }


}
