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
}
