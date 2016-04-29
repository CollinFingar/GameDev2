﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Vector3 zoomedOutPosition = new Vector3(0f, 0f, -10f);
    public Vector3 zoomedInPostion = new Vector3(0f, 0f, -10f);
    public float zoomedOutScale = 5;
    public float zoomedInScale = 3;

    private bool movingIn = false;
    private bool movingOut = false;
	public bool isZoomed = false;
	public bool isMoving = false; //combination of movingIn and movingOut for use in other scripts
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
	public GameObject war;
	public WarScript wsc;

    public AudioSource soundSource;
    public AudioClip zoomInSound;
    public AudioClip zoomOutSound;

	// Use this for initialization
	void Start () {
        canvas.gameObject.SetActive(false);
        tScript = timer.GetComponent<TimerScript>();
		wsc = war.GetComponent<WarScript>();
	}
	
	// Update is called once per frame
	void Update () {
		isMoving = (movingIn || movingOut);
		if (isMoving) {
			tScript.paused = true;
		}
        if (movingIn){
            updateMoveIn();
        } else if (movingOut){
            updateMoveOut();
        }
    }

    public void moveIn(GameObject location){
        tScript.paused = true;
		wsc.isZoomed = true;
        zoomedInPostion = new Vector3(location.transform.position.x + 1,
                                       location.transform.position.y,
                                       -10);
        mainInterface.SetActive(false);
        startTime = Time.time;
        currentMovingTime = startTime;
        movingIn = true;
        interfaceCanvas.gameObject.SetActive(false);
        playZoomInSound();
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
		wsc.isZoomed = false;
        //mainCameraScript.orthographicSize = zoomedOutScale;
        mainInterface.SetActive(true);
        startTime = Time.time;
        currentMovingTime = startTime;
        movingOut = true;
        canvas.gameObject.SetActive(false);
        playZoomOutSound();
    }
    void updateMoveOut(){
        float distCovered = (Time.time - startTime) * speed;
        currentMovingTime = Time.time - startTime;
        mainCameraScript.orthographicSize = zoomedOutScale * currentMovingTime / moveTime + zoomedInScale * (1 - currentMovingTime / moveTime);
        transform.position = Vector3.Lerp(zoomedInPostion, zoomedOutPosition, currentMovingTime / moveTime);
        if (transform.position == zoomedOutPosition)
        {
			tScript.paused = false;
            mainCameraScript.orthographicSize = zoomedOutScale;
            movingOut = false;
            interfaceCanvas.gameObject.SetActive(true);
        }
    }


    public void playZoomInSound()
    {
        soundSource.PlayOneShot(zoomInSound, 1F);
    }

    public void playZoomOutSound()
    {
        soundSource.PlayOneShot(zoomOutSound, 1F);
    }


}
