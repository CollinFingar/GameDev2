using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour {
    public float alpha = 0;
    public float rate = .01f;

    public float pauseTime = 1f;

    public  Text t1;
    public Text t2;

    private bool goingDown = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!goingDown) {
            if (alpha + rate >= 1) {
                alpha = 1;
                goingDown = true;
                pauseTime = Time.time + 1;
            } else {
                alpha += rate;
            }
        } else if(goingDown && Time.time > pauseTime) {
            if (alpha - rate <= 0) {
                alpha = 0;
                SceneManager.LoadScene(0);
            } else {
                alpha -= rate;
            }
        }
        t1.color = new Color(t1.color.r, t1.color.g, t1.color.b, alpha);
        t2.color = new Color(t2.color.r, t2.color.g, t2.color.b, alpha);
    }
}
