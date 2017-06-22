using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapperScript : MonoBehaviour {

    public float scaleSpeed;
    public float maxScale;
    public int index;

    private Transform[] snappers;
    private Vector3[] originalScale;
    private bool growing;
    private float startCounter;

	// Use this for initialization
	void Start () {
        snappers = new Transform[2];
        snappers[0] = transform.GetChild(0);
        snappers[1] = transform.GetChild(1);

        originalScale = new Vector3[2];
        originalScale[0] = snappers[0].localScale;
        originalScale[1] = snappers[1].localScale;

        growing = true;
        startCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        startCounter += Time.deltaTime;
        if (startCounter < index) return;

        Vector3 curScale = snappers[0].localScale;
        if (growing) curScale.x += scaleSpeed * Time.deltaTime;
        else curScale.x -= scaleSpeed * Time.deltaTime;

        snappers[0].localScale = curScale;
        snappers[1].localScale = curScale;

        if (curScale.x > maxScale) growing = false;
        else if (curScale.x < 0) growing = true;
	}
}
