using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WriteNamesScript : MonoBehaviour {

    public TextAsset text;

    public int sceneNum = 2;

	// Use this for initialization
	void Start () {
        Debug.Log(text.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartTheShow()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
