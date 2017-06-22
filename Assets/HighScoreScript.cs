using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreScript : MonoBehaviour {

    public GameManager gameManager;
    private TextMesh text;

	// Use this for initialization
	void Start () { 
        text = GetComponent<TextMesh>();    
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.currentMode == GameManager.Mode.MENU) text.text = "HIGHSCORE: " + PlayerPrefs.GetFloat("high_score", 45.3689f);
        else text.text = "";
    }
}
