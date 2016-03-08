using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContractScript : MonoBehaviour {
    public int Faction = 0;
    public int RewardAmount = 0;
    public int CostAmount = 0;
    public int CostType = 0;
	private string type;
	public int PowerReward = 0;
    public float DecayRate = 0;
	public float moveTime = 0;
	public int moveType = 0; //type of movement (0 = creation, 1 = expire)
	Text desc;

	public GameObject player;

	public bool completed = false;

	private int[] values = new int[4];

	public GameObject myFaction;
	// Use this for initialization
	void Start () {
		if (CostType == 0) {
			type = "Shield";
		}

		if (CostType == 1) {
			type = "Guns";
		}

		if (CostType == 2) {
			type = "Explosives";
		}

		if (CostType == 3) {
			type = "Ships";
		}

		player = GameObject.FindGameObjectWithTag ("Player");
		desc = this.gameObject.GetComponentInChildren<Text> ();
		desc.text = type+"\n"+CostAmount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveTime > 0) 
		{
			moveContract ();
		}
		drawContract ();
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

	void drawContract() {
		
	}

    void OnMouseEnter()
    {
		if (completed == false) {
			SetHoverColor ();
		}
    }

    void OnMouseExit()
    {
		if (completed == false) {
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
		if (completed == false) {
			if (type == "Shield") {
				if (player.GetComponent<PlayerScript> ().resourceA >= (3 * CostAmount) && player.GetComponent<PlayerScript> ().resourceB >= (2 * CostAmount)) {
					player.GetComponent<PlayerScript> ().resourceA -= (3 * CostAmount);
					player.GetComponent<PlayerScript> ().resourceB -= (2 * CostAmount);
					player.GetComponent<PlayerScript> ().money += RewardAmount;
					SetCompletedColor ();
					myFaction.GetComponent<FactionScript> ().power += PowerReward;
					completed = true;
				}
			}

			if (type == "Guns") {
				if (player.GetComponent<PlayerScript> ().resourceA >= (2 * CostAmount) && player.GetComponent<PlayerScript> ().resourceC >= (3 * CostAmount)) {
					player.GetComponent<PlayerScript> ().resourceA -= (2 * CostAmount);
					player.GetComponent<PlayerScript> ().resourceC -= (3 * CostAmount);
					player.GetComponent<PlayerScript> ().money += RewardAmount;
					SetCompletedColor ();
					myFaction.GetComponent<FactionScript> ().power += PowerReward;
					completed = true;
				}
			}

			if (type == "Explosives") {
				if (player.GetComponent<PlayerScript> ().resourceB >= (3 * CostAmount) && player.GetComponent<PlayerScript> ().resourceC >= (2 * CostAmount)) {
					player.GetComponent<PlayerScript> ().resourceC -= (2 * CostAmount);
					player.GetComponent<PlayerScript> ().resourceB -= (3 * CostAmount);
					player.GetComponent<PlayerScript> ().money += RewardAmount;
					myFaction.GetComponent<FactionScript> ().power += PowerReward;
					SetCompletedColor ();
					completed = true;
				}
			}

			if (type == "Ships") {
				if (player.GetComponent<PlayerScript> ().resourceA >= (2 * CostAmount) && player.GetComponent<PlayerScript> ().resourceB >= (2 * CostAmount) && player.GetComponent<PlayerScript> ().resourceC >= (2 * CostAmount)) {
					player.GetComponent<PlayerScript> ().resourceA -= (2 * CostAmount);
					player.GetComponent<PlayerScript> ().resourceC -= (2 * CostAmount);
					player.GetComponent<PlayerScript> ().resourceB -= (2 * CostAmount);
					player.GetComponent<PlayerScript> ().money += RewardAmount;
					myFaction.GetComponent<FactionScript> ().power += PowerReward;
					SetCompletedColor ();
					completed = true;
				}
			}
		}

        Debug.Log("You hit: " + gameObject.name);

    }


}
