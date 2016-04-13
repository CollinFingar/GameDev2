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

    private bool longTerm = false;

    public Button b1;
    public Button b2;

    public Image publicLeaderImage;
    public Sprite spriteLeader;

    public GameObject player;
    private PlayerScript ps;

    public bool movedIn = false;

    public GameObject blueParticle;
    public GameObject greenParticle;
    public GameObject redParticle;

    public int mineNumberIterations = 5;
    public float mineNumberResourceIncrease = 1.5f;
    public float mineNumberMoneyIncrease = 1.5f;

    public AudioClip buy;
    public AudioClip build; 

    private ArrayList mines = new ArrayList();
        //Arraylist of arraylists
            //0 = num iterations left
            //1 = resource type to give
            //2 = resource amount to give
            //3 = which action made this
    public bool onlyOneMine = true;
    private bool b1Mine = false;
    private bool b2Mine = false;

    public GameObject leftNeighbor;
    public GameObject rightNeighbor;

    public bool metalMine = false;
    public bool plasmaMine = false;
    public bool fuelMine = false;

	public GameObject spr_mM;
	public GameObject spr_pM;
	public GameObject spr_fM;


    // Use this for initialization
    void Start () {
        cs = mainCamera.GetComponent<CameraScript>();
        ps = player.GetComponent<PlayerScript>();
        

        setPlanetInfo();
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
            b1.GetComponentInChildren<Text>().text = b1Cost.ToString() + " Money -> " + b1Reward.ToString() + " " + b1RewardType;
            b2.GetComponentInChildren<Text>().text = b2Cost.ToString() + " Money -> " + b2Reward.ToString() + " " + b2RewardType;
            ps.assignPlanet(gameObject);
            publicLeaderImage.sprite = spriteLeader;
        } else {
            cs.moveOut();
            movedIn = false;
        }
        
    }

    public void doB1Action() {
        Debug.Log("Doing B1 action for " + planetName);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            longTerm = true;
        } else {
            longTerm = false;
        }

        if (!longTerm) {
            if (ps.money >= b1Cost) {
                ps.money -= b1Cost;
                ps.increaseResource(b1RewardType, b1Reward);
                //spawnResource("B");
                playBuySound();
            }
        } else {
            if (ps.money >= b1Cost && !b1Mine) {
                playBuildSound();
                ps.money -= b1Cost;
                ArrayList mine = new ArrayList();
                mine.Add(mineNumberIterations);
                mine.Add(b1RewardType);
                int rewaredAmount = (int)(b1Reward * mineNumberResourceIncrease / mineNumberIterations);
                increasePSIncome(b1RewardType, rewaredAmount);
                mine.Add(rewaredAmount);
                mine.Add(1);
                b1Mine = true;
                mines.Add(mine);
                updateSymbols(b1RewardType, true);
            }
        }

    }

    public void doB2Action()
    {
        Debug.Log("Doing B2 action for " + planetName);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            longTerm = true;
        } else {
            longTerm = false;
        }

        if (!longTerm)
        {
            if (ps.money >= b2Cost)
            {
                ps.money -= b2Cost;
                ps.increaseResource(b2RewardType, b2Reward);
                //spawnResource("B");
                playBuySound();
            }
        }
        else
        {
            if (ps.money >= b2Cost && !b2Mine)
            {
                playBuildSound();
                ps.money -= b2Cost;
                ArrayList mine = new ArrayList();
                mine.Add(mineNumberIterations);
                mine.Add(b2RewardType);
                int rewaredAmount = (int)(b2Reward * mineNumberResourceIncrease / mineNumberIterations);
                increasePSIncome(b2RewardType, rewaredAmount);
                mine.Add(rewaredAmount);
                mine.Add(2);
                b2Mine = true;
                mines.Add(mine);
                updateSymbols(b2RewardType, true);
            }
        }
    }

    public void spawnResource(string RewardType) {
        if (RewardType == "Metal") {
            Instantiate(blueParticle, new Vector3(transform.position.x,
                                      transform.position.y,
                                      -1), Quaternion.identity);
        } else if(RewardType == "Plasma") {
            Instantiate(greenParticle, new Vector3(transform.position.x,
                                     transform.position.y,
                                     -1), Quaternion.identity);
        } else if(RewardType == "Fuel") {
            Instantiate(redParticle, new Vector3(transform.position.x,
                                     transform.position.y,
                                     -1), Quaternion.identity);
        }

        //instance.transform.position = gameObject.transform.position;
    }

    public void contractsFinish() {
        for (int i = 0; i < mines.Count; i++) {
            ArrayList mine = (ArrayList)mines[i];
            int numIterations = (int)mine[0] - 1;
            string resourceType = (string)mine[1];
            int resourceAmount = (int)mine[2];
            ps.increaseResource(resourceType, resourceAmount);

            spawnResource(resourceType);

            if (numIterations == 0)
            {
                if ((int)mine[3] == 1) {
                    b1Mine = false;
                } else {
                    b2Mine = false;
                }
                updateSymbols(resourceType, false);
                decreasePSIncome(resourceType, resourceAmount);
                mines.RemoveAt(i);
            }
            else {
                mine[0] = numIterations;
            }


        }
    }

    public void setPlanetInfo() {
        if (planetName == "ArrPeeAye") {
            planetInfo = "\"Welcome to our planet of scholars. For those worthy of paying the glorious tax, opportunities are abundant to serve the Empire.\n\nWe are open to trading metal that is left-over from building top-of-the-line tech, as well as element zero.\"\n\n - The Honorable";
        } else if(planetName == "O'Malley's Orb") {
            planetInfo = "\"Hello, dear friend! Welcome to the Orb! Here, we’re all as clever as clovers, don’tcha know!\n\nPlasma is what we have to sell, to be sure! We’re also willing to spill the Empire’s beer, if you catch my meaning!\"\n\n-Chloe the Lucky";
        } else if(planetName == "Enterpronia") {
            planetInfo = "\"Greetings, I am so glad you beamed down here. Our phasers are never set to stun in this hostile area.\n\nI spoke with Spook, and we have a surplus of metal and plasma, if trading was on your mind.\"\n\n-Captain Dirk";
        }
    }

    public void playBuySound() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(buy, 0.7F);
    }

    public void playBuildSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(build, 0.7F);
    }

    public void increasePSIncome(string rewardType, int reward) {
        if (rewardType == "Metal") {
            ps.metalIncome += reward;
        } else if (rewardType == "Fuel") {
            ps.fuelIncome += reward;
        } else if (rewardType == "Plasma") {
            ps.plasmaIncome += reward;
        }
    }

    public void decreasePSIncome(string rewardType, int reward) {
        if (rewardType == "Metal") {
            ps.metalIncome -= reward;
        } else if (rewardType == "Fuel") {
            ps.fuelIncome -= reward;
        } else if (rewardType == "Plasma") {
            ps.plasmaIncome -= reward;
        }
    }

    public void updateSymbols(string type, bool building) {
        if (building) {
            if (type == "Metal") {
				metalMine = true;	
				spr_mM.SetActive (true);
            } else if(type == "Plasma") {
                plasmaMine = true;
				spr_pM.SetActive (true);
            } else if(type == "Fuel") {
                fuelMine = true;
				spr_fM.SetActive (true);
            }
        } else {
            if (type == "Metal") {
                metalMine = false;
				spr_mM.SetActive (false);
            } else if(type == "Plasma") {
                plasmaMine = false;
				spr_pM.SetActive (false);
            } else if(type == "Fuel") {
                fuelMine = false;
				spr_fM.SetActive (false);
            }
        }
    }

}
