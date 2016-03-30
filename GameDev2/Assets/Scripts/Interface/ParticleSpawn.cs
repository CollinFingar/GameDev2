using UnityEngine;
using System.Collections;

public class ParticleSpawn : MonoBehaviour {
    
    public float floatSpeed = .1f;
    public float alphaSpeed = .05f;

    private SpriteRenderer sr;

    private float alpha = 1f;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (alpha > 0) {
            alpha -= alphaSpeed*Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + floatSpeed*Time.deltaTime, transform.position.z);
            sr.color = new Color(1, 1, 1, alpha);
        } else {
            Destroy(gameObject);
        }
	    
	}
}
