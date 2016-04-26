using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		if (GameObject.Find("Audio Source").gameObject != this.gameObject) {
			Destroy (this.gameObject);
			return;
		}
		DontDestroyOnLoad (this.gameObject);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("War") != null) {
			Destroy (this.gameObject);
			return;
		}
	}
}
