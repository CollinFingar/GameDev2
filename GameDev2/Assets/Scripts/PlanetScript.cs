using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlanetScript : MonoBehaviour {

    public string planetName = "Nilloc 244";

    public string planetInfo = "I'm a placeholder for info\nenter\nenter\nmore stufff lololol";
    public string button1String = "Do this Action";
    public string button2String = "Do THIS Action";
    public Camera mainCamera;
    private CameraScript cs;

    public Text planetNameTextObject;
    public Text planetInfoTextObject;

    public int b1Cost = 10;
    public int b1Reward = 10;
    public string b1RewardType = "Metal";

    public int b2Cost = 10;
    public int b2Reward = 10;
    public string b2RewardType = "Plasma";


    public Button b1;
    public Button b2;

    public GameObject player;
    private PlayerScript ps;

    public bool movedIn = false;

    public ParticleSystem blueParticleSystem;
    public ParticleSystem greenParticleSystem;
    public ParticleSystem redParticleSystem;


    // Use this for initialization
    void Start () {
        cs = mainCamera.GetComponent<CameraScript>();
        ps = player.GetComponent<PlayerScript>();

        blueParticleSystem.enableEmission = false;
        greenParticleSystem.enableEmission = false;
        redParticleSystem.enableEmission = false;

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown() {
        if (!movedIn) {
            cs.moveIn(gameObject);
            movedIn = true;
            planetNameTextObject.text = planetName;
            planetInfoTextObject.text = planetInfo;
            b1.GetComponentInChildren<Text>().text = "Money -> " + b1RewardType;
            b2.GetComponentInChildren<Text>().text = "Money -> " + b2RewardType;
            ps.assignPlanet(gameObject);
        } else {
            cs.moveOut();
            movedIn = false;
        }
        
    }

    public void doB1Action() {
        Debug.Log("Doing B1 action for " + planetName);
        if (ps.money >= b1Cost) {
            ps.money -= b1Cost;
            ps.increaseResource(b1RewardType, b1Reward);
            spawnResource("B");
        }
    }

    public void doB2Action()
    {
        Debug.Log("Doing B2 action for " + planetName);
        if (ps.money >= b2Cost)
        {
            ps.money -= b2Cost;
            ps.increaseResource(b2RewardType, b2Reward);
            spawnResource("B");
        }
    }

    public void spawnResource(string b2RewardType) {
        blueParticleSystem.enableEmission = true;

        //instance.transform.position = gameObject.transform.position;
    }


}
