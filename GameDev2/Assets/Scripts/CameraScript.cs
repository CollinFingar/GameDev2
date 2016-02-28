using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Vector3 zoomedOutPosition = new Vector3(0f, 0f, -10f);
    public Vector3 zoomedInPostion = new Vector3(0f, 0f, -10f);
    public float zoomedOutScale = 5;
    public float zoomedInScale = 3;

    private bool movingIn = false;
    private bool movingOut = false;
    public float speed = .1f;
    public float journeyLength = 1f;

    private float startTime = 0f;

    public Camera mainCameraScript;
    public GameObject mainInterface;

    public GameObject testObject;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            moveIn(testObject);
        } else if (Input.GetKeyDown(KeyCode.X)){
            moveOut();
        }
        if (movingIn){
            updateMoveIn();
        } else if (movingOut){
            updateMoveOut();
        }
    }

    public void moveIn(GameObject location){
        zoomedInPostion = new Vector3(location.transform.position.x + 1,
                                       location.transform.position.y,
                                       -10);
        mainInterface.SetActive(false);
        startTime = Time.time;
        journeyLength = Vector3.Distance(zoomedOutPosition, zoomedInPostion);
        movingIn = true;
    }
    void updateMoveIn(){
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        mainCameraScript.orthographicSize = zoomedInScale * fracJourney + zoomedOutScale * (1 - fracJourney);
        transform.position = Vector3.Lerp(zoomedOutPosition, zoomedInPostion, fracJourney);
        if(transform.position == zoomedInPostion)
        {
            movingIn = false;
        }
    }

    public void moveOut(){
        mainCameraScript.orthographicSize = zoomedOutScale;
        mainInterface.SetActive(true);
        journeyLength = Vector3.Distance(zoomedOutPosition, zoomedInPostion);
        startTime = Time.time;
        movingOut = true;
    }
    void updateMoveOut(){
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        mainCameraScript.orthographicSize = zoomedOutScale * fracJourney + zoomedInScale * (1 - fracJourney);
        transform.position = Vector3.Lerp(zoomedInPostion, zoomedOutPosition, fracJourney);
        if (transform.position == zoomedOutPosition)
        {
            movingOut = false;
        }
    }
}
