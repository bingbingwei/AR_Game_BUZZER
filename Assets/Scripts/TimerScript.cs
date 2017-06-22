using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    private Text timerText;
    private string timeHeader = "TIME: ";

    public float time;
    private bool counting;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
        time = 0;
        counting = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (counting) time += Time.deltaTime;
        timerText.text = timeHeader + time.ToString("F2");
    }

    void Reset()
    {
        time = 0;
        counting = true;
    }

    void Stop()
    {
        counting = false;
    }
}
