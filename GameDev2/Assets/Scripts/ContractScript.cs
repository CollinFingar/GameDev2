using UnityEngine;
using System.Collections;

public class ContractScript : MonoBehaviour {
    public int Faction = 0;
    public float RewardAmount = 0;
    public float CostAmount = 0;
    public float CostType = 0;
    public float DecayRate = 0;
	public float moveTime = 0;
	public int moveType = 0; //type of movement (0 = creation, 1 = expire)

	// Use this for initialization
	void Start () {
	
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
			this.transform.position = new Vector2(this.transform.position.x,newY);
			moveTime--;
			if (moveTime == 0) 
			{
				moveType = 1;
			}
		}
		else if (moveType == 1)
		{
			float newX = this.transform.position.x - (1 - 2*(Faction-1)) * (50/moveTime *.17f);
			this.transform.position = new Vector2(newX,this.transform.position.y);
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
        SetHoverColor();
    }

    void OnMouseExit()
    {
        ResetColor();
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
        Debug.Log("You hit: " + gameObject.name);
    }


}
