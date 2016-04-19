using UnityEngine;
using System.Collections;

public class InOutScript : MonoBehaviour {
    public float maxSize = 1f;
    public float minSize = .1f;

    public float speed = .02f;

    public float size = 1f;

    public bool startMax = true;

    private bool decreasing = true;


	// Use this for initialization
	void Start () {
        decreasing = startMax;
        if (decreasing) {
            size = maxSize;
        } else {
            size = minSize;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (decreasing) {
            size -= speed;
            transform.localScale = new Vector3(size, size, 1);
            if (size <= minSize) {
                decreasing = false;
            }
        } else {
            size += speed;
            transform.localScale = new Vector3(size, size, 1);
            if (size >= maxSize)
            {
                decreasing = true;
            }
        }
	}
}
