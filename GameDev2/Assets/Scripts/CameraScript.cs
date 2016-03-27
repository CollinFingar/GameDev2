﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Vector3 zoomedOutPosition = new Vector3(0f, 0f, -10f);
    public Vector3 zoomedInPostion = new Vector3(0f, 0f, -10f);
    public float zoomedOutScale = 5;
    public float zoomedInScale = 3;

    private bool movingIn = false;
    private bool movingOut = false;
    public float speed = .1f;

    private float startTime = 0f;
    private float currentMovingTime = 0f;
    public float moveTime = 0.5f;

    public Camera mainCameraScript;
    public GameObject mainInterface;

    public GameObject testObject;

    public Canvas canvas;
    public Canvas interfaceCanvas;

    public GameObject timer;
    public TimerScript tScript;

	// Use this for initialization
	void Start () {
        canvas.gameObject.SetActive(false);
        tScript = timer.GetComponent<TimerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (movingIn){
            updateMoveIn();
        } else if (movingOut){
            updateMoveOut();
        }
    }

    public void moveIn(GameObject location){
        tScript.paused = true;
        zoomedInPostion = new Vector3(location.transform.position.x + 1,
                                       location.transform.position.y,
                                       -10);
        mainInterface.SetActive(false);
        startTime = Time.time;
        currentMovingTime = startTime;
        movingIn = true;
        interfaceCanvas.gameObject.SetActive(false);
    }
    void updateMoveIn(){
        float distCovered = (Time.time - startTime) * speed;
        currentMovingTime = Time.time - startTime;
        mainCameraScript.orthographicSize = zoomedInScale * currentMovingTime / moveTime + zoomedOutScale * (1 - currentMovingTime / moveTime);
        transform.position = Vector3.Lerp(zoomedOutPosition, zoomedInPostion, currentMovingTime/moveTime);
        if(transform.position == zoomedInPostion)
        {
            mainCameraScript.orthographicSize = zoomedInScale;
            movingIn = false;
            canvas.gameObject.SetActive(true);
        }
    }

    public void moveOut(){
        tScript.paused = false;
        //mainCameraScript.orthographicSize = zoomedOutScale;
        mainInterface.SetActive(true);
        startTime = Time.time;
        currentMovingTime = startTime;
        movingOut = true;
        canvas.gameObject.SetActive(false);
    }
    void updateMoveOut(){
        float distCovered = (Time.time - startTime) * speed;
        currentMovingTime = Time.time - startTime;
        mainCameraScript.orthographicSize = zoomedOutScale * currentMovingTime / moveTime + zoomedInScale * (1 - currentMovingTime / moveTime);
        transform.position = Vector3.Lerp(zoomedInPostion, zoomedOutPosition, currentMovingTime / moveTime);
        if (transform.position == zoomedOutPosition)
        {
            mainCameraScript.orthographicSize = zoomedOutScale;
            movingOut = false;
            interfaceCanvas.gameObject.SetActive(true);
        }
    }
}
