using UnityEngine;
using System.Collections;

public class TwinkleScript : MonoBehaviour {

	private float nextTwinkle = 0;

	private SpriteRenderer sr;

	private bool twinkling = false;
	private bool twinklingDown = false;
	private float alph = 1f;
	public float rate = .1f;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		nextTwinkle = Time.time + Random.Range (0, 10.4f);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Time.time);
		if (!twinkling && Time.time >= nextTwinkle) {
			twinkling = true;
			twinklingDown = true;
		} else if (twinkling) {
			if (twinklingDown) {
				if (alph <= .05) {
					alph = 0;

					twinklingDown = false;
				} else {
					alph -= rate;
				}
			} else {
				if (alph >= .95) {
					alph = 1;
					twinkling = false;
					nextTwinkle = Time.time + Random.Range (4, 14.4f);
				} else {
					alph += rate;
				}
			}
			sr.color = new Color(1,1,1,alph);
		}
	}
}
