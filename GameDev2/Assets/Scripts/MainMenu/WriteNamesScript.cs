using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class WriteNamesScript : MonoBehaviour {

    public TextAsset text;

	public InputField if1;
	public InputField if2;

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



		StreamWriter  writer = new StreamWriter("Assets/Resources/Names.txt"); // Does this work?
		writer.Write("");

		writer.WriteLine(if1.text);
		writer.WriteLine(if2.text);
		writer.Close ();


        SceneManager.LoadScene(sceneNum);
    }
}
