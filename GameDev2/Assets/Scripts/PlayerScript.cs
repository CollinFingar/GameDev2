using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float money = 0;
    public float resourceMetal = 0;
    public float resourceFuel = 0;
    public float resourcePlasma = 0;

    public Text moneyText;
    public Text AText;
    public Text BText;
    public Text CText;

    private GameObject planetViewing;

    public Button planetB1;
    public Button planetB2;

    // Use this for initialization
    void Start () {
        //Screen.SetResolution(100, 80, true);
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "$: "+money.ToString();
        AText.text = "Metal: "+ resourceMetal.ToString();
        BText.text = "Fuel: "+ resourceFuel.ToString();
        CText.text = "Plasma: "+ resourcePlasma.ToString();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void assignPlanet(GameObject p) {
        planetViewing = p;
    }

    public void doPlanetB1Action() {
        planetViewing.GetComponent<PlanetScript>().doB1Action();
    }

    public void doPlanetB2Action()
    {
        planetViewing.GetComponent<PlanetScript>().doB2Action();
    }

    public void increaseResource(string type, int amount) {
        if (type == "Metal") {
            resourceMetal += amount;
        } else if (type == "Fuel")
        {
            resourceFuel += amount;
        }
        else if (type == "Plasma")
        {
            resourcePlasma += amount;
        }
    }
}
