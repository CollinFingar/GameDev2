using UnityEngine;
using System.Collections;

public class ContractScript : MonoBehaviour {
    public float Faction = 0;
    public float RewardAmount = 0;
    public float CostAmount = 0;
    public float CostType = 0;
    public float DecayRate = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
