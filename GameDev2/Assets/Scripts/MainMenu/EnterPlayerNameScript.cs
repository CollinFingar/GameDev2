using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class EnterPlayerNameScript : MonoBehaviour {
	public TextAsset text;

	public InputField if1;

	public int sceneNum = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartTheShow()
	{

		StreamWriter  writer = new StreamWriter("Assets/Resources/LatestScore.txt", true);

		writer.WriteLine(if1.text);
		writer.Close ();


		SceneManager.LoadScene(sceneNum);
	}


}
