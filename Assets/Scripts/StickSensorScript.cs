using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSensorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        // if (collider.gameObject.name == "Stick") Debug.Log("in");
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Stick")
        {
            // Debug.Log("out");
            GameObject.Find("GameManager").SendMessage("GameOver", false);
        }
    }
}
