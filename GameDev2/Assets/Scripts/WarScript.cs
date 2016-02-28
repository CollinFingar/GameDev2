using UnityEngine;
using System.Collections;

public class WarScript : MonoBehaviour {
    public GameObject Faction1;
    public GameObject Faction2;
    
    public float warStatus = .5f;

    public GameObject colors;
    public float farRightX = 6f;
    public float farLeftX = -6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)){
            if(warStatus < 1)
            {
                warStatus += .01f;
            }
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            if(warStatus > 0)
            {
                warStatus -= .01f;
            }
        }
        colors.transform.position = new Vector3(farRightX * warStatus + farLeftX * (1 - warStatus), transform.position.y, transform.position.z);
	}
}
