using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class PlayerScript : MonoBehaviour {

    public float money = 0;
    public float resourceMetal = 0;
    public float resourceFuel = 0;
    public float resourcePlasma = 0;

    public float moneyDisplayed = 0;
    public float resourceMetalDisplayed = 0;
    public float resourceFuelDisplayed = 0;
    public float resourcePlasmaDisplayed = 0;

    public Text moneyText;
    public Text AText;
    public Text BText;
    public Text CText;

    public Text AIncomeText;
    public Text BIncomeText;
    public Text CIncomeText;

	public Text Faction1Name;
	public Text Faction2Name;

    private GameObject planetViewing;

    public Button planetB1;
    public Button planetB2;

    public int metalIncome = 0;
    public int fuelIncome = 0;
    public int plasmaIncome = 0;

    public int resourceDisplayTick = 1;
    public int moneyDisplayTick = 10;

    // Use this for initialization
    void Start () {
		StreamReader sr = new StreamReader ("Assets/Resources/Names.txt");
		Faction1Name.text = sr.ReadLine ();
		Faction2Name.text = sr.ReadLine ();
	}
	
	// Update is called once per frame
	void Update () {
        incrementValues();

        moneyText.text = "$: "+ moneyDisplayed.ToString();
        AText.text = "Metal: "+ resourceMetalDisplayed.ToString();
        BText.text = "Fuel: "+ resourceFuelDisplayed.ToString();
        CText.text = "Plasma: "+ resourcePlasmaDisplayed.ToString();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        AIncomeText.text = "+ " + metalIncome;
        BIncomeText.text = "+ " + fuelIncome;
        CIncomeText.text = "+ " + plasmaIncome;
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

    public void incrementValues() {
        if (moneyDisplayed != money) {
            if (moneyDisplayed < money) {
                if (money - moneyDisplayed >= moneyDisplayTick) {
                    moneyDisplayed += moneyDisplayTick;
                } else {
                    moneyDisplayed += (money - moneyDisplayed);
                }
            } else {
                if (moneyDisplayed - money >= moneyDisplayTick) {
                    moneyDisplayed -= moneyDisplayTick;
                } else {
                    moneyDisplayed -= (moneyDisplayed - money);
                }
            }
        }

        if (resourceMetalDisplayed != resourceMetal) {
            if (resourceMetalDisplayed < resourceMetal) {
                if (resourceMetal - resourceMetalDisplayed >= resourceDisplayTick) {
                    resourceMetalDisplayed += resourceDisplayTick;
                } else {
                    resourceMetalDisplayed += (resourceMetal - resourceMetalDisplayed);
                }
            } else {
                if (resourceMetalDisplayed - resourceMetal >= resourceDisplayTick) {
                    resourceMetalDisplayed -= resourceDisplayTick;
                } else {
                    resourceMetalDisplayed -= (resourceMetalDisplayed - resourceMetal);
                }
            }
        }

        if (resourceFuelDisplayed != resourceFuel) {
            if (resourceFuelDisplayed < resourceFuel) {
                if (resourceFuel - resourceFuelDisplayed >= resourceDisplayTick) {
                    resourceFuelDisplayed += resourceDisplayTick;
                } else {
                    resourceFuelDisplayed += (resourceFuel - resourceFuelDisplayed);
                }
            } else {
                if (resourceFuelDisplayed - resourceFuel >= resourceDisplayTick) {
                    resourceFuelDisplayed -= resourceDisplayTick;
                } else {
                    resourceFuelDisplayed -= (resourceFuelDisplayed - resourceFuel);
                }
            }
        }

        if (resourcePlasmaDisplayed != resourcePlasma) {
            if (resourcePlasmaDisplayed < resourcePlasma) {
                if (resourcePlasma - resourcePlasmaDisplayed >= resourceDisplayTick) {
                    resourcePlasmaDisplayed += resourceDisplayTick;
                } else {
                    resourcePlasmaDisplayed += (resourcePlasma - resourcePlasmaDisplayed);
                }
            } else {
                if (resourcePlasmaDisplayed - resourcePlasma >= resourceDisplayTick) {
                    resourcePlasmaDisplayed -= resourceDisplayTick;
                } else {
                    resourcePlasmaDisplayed -= (resourcePlasmaDisplayed - resourcePlasma);
                }
            }
        }
    }
}
