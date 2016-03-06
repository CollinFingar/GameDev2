using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float money = 111;
    public float resourceA = 222;
    public float resourceB = 333;
    public float resourceC = 444;

    public Text moneyText;
    public Text AText;
    public Text BText;
    public Text CText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = money.ToString();
        AText.text = resourceA.ToString();
        BText.text = resourceB.ToString();
        CText.text = resourceC.ToString();
    }
}
