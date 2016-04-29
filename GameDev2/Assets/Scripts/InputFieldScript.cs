using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class InputFieldScript : MonoBehaviour {
	int sel = 0; //current field selection
	public InputField[] fields;
	// Use this for initialization
	void Start () {
		fields [0].ActivateInputField ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			fields [sel].DeactivateInputField ();
			if (sel >= fields.Length - 1) {
				sel = 0;
			} else {
				sel++;
			}
			fields [sel].ActivateInputField ();
		}
	}
}
