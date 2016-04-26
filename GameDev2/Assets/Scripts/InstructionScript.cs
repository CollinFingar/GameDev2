using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionScript : MonoBehaviour {

	int cur_index;
	public Sprite[] instructions; 
	public Image myImage; //this object's image

	// Use this for initialization
	void Start () {
		cur_index = 0; //sets the first instruction image to be visible at star
		myImage.sprite = instructions[cur_index];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextImage() {
		if (cur_index < (instructions.Length - 1)) 
		{
			cur_index++;
		} 
		else 
		{
			cur_index = 0;
		}
		myImage.sprite = instructions [cur_index];		
	}
}
