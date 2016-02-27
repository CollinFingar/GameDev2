using UnityEngine;
using System.Collections;

public class PlanetActionButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter() {
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
        GetComponent<SpriteRenderer>().color = new Color(.7f, .7f, .7f, 1f);
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
