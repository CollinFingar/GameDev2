using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

    public int sceneNum = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        StartTheShow();
    }

    public void StartTheShow() {
		if (sceneNum == -1) {
			Application.Quit ();
		} else {
			SceneManager.LoadScene(sceneNum);
		}
    }
}
