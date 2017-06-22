using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition(); // Cancel this to disable keyboard input
	}

    void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("GameManager").SendMessage("GameOver", false);
    }

    void OnCollisionExit(Collision collision)
    {

    }

    void UpdatePosition()
    {
        Vector3 curPos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow)) curPos.z -= moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) curPos.x += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) curPos.z += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) curPos.x -= moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) curPos.y += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) curPos.y -= moveSpeed * Time.deltaTime;

        transform.position = curPos;
    }
}
