using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlanetScript : MonoBehaviour {

    public string planetName = "Nilloc 244";

    public string planetInfo = "I'm a placeholder for info\nenter\nenter\nmore stufff lololol";

    public Camera mainCamera;
    private CameraScript cs;

    public Text planetNameTextObject;
    public Text planetInfoTextObject;

    public Button b1;
    public Button b2;

    public bool movedIn = false;

	// Use this for initialization
	void Start () {
        cs = mainCamera.GetComponent<CameraScript>();
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
        } else {
            cs.moveOut();
            movedIn = false;
        }
        
    }


}
