using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float money = 0;
    public float resourceA = 0;
    public float resourceB = 0;
    public float resourceC = 0;

    public Text moneyText;
    public Text AText;
    public Text BText;
    public Text CText;

    private GameObject planetViewing;

    public Button planetB1;
    public Button planetB2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "$: "+money.ToString();
        AText.text = "A: "+resourceA.ToString();
        BText.text = "B: "+resourceB.ToString();
        CText.text = "C: "+resourceC.ToString();
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
        if (type == "A") {
            resourceA += amount;
        } else if (type == "B")
        {
            resourceB += amount;
        }
        else if (type == "C")
        {
            resourceC += amount;
        }
    }
}
