using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // NOTE: game object stick must be named "Stick"

    public GameObject[] tracks;
    private GameObject curTrack;

    public GameObject timer;
    public GameObject gameOver;

    public enum Mode
    {
        MENU = -1, // At game menu (start or leaderboard)
        START = 0, // Entered level but hasn't begun
        GAMING = 1, // Began level
        END = 2 // End level
    };
    public Mode currentMode;

	// Use this for initialization
	void Start () {
        currentMode = Mode.MENU;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BeginLevel()
    {
        // Choose random track and instantiate
        int idx = Random.Range(0, tracks.Length);
        curTrack = Instantiate(tracks[idx]);
        currentMode = Mode.START;
    }

    void StartGame()
    {
        // When stick enters starting point
        if (currentMode == Mode.START)
        {
            Debug.Log("start");
            currentMode = Mode.GAMING;
            timer.SetActive(true);
            timer.SendMessage("Reset");
        }
    }

    void GameOver(bool success)
    {
        // When stick enters ending point or touches the track
        if (timer.activeSelf) timer.SendMessage("Stop");
        if (currentMode == Mode.GAMING)
        {
            if (!success)
            {
                gameOver.SetActive(true);
                Debug.Log("game over");
            }
            else
            {
                float highScore = PlayerPrefs.GetFloat("high_score");
                float score = timer.GetComponent<TimerScript>().time;
                if (score < highScore) PlayerPrefs.SetFloat("high_score", timer.GetComponent<TimerScript>().time);
                Debug.Log("success");
            }
            currentMode = Mode.END;
            Invoke("Restart", 3f);
        }

    }

    void Restart()
    {
        gameOver.SetActive(false);
        timer.SetActive(false);
        Destroy(curTrack);

        currentMode = Mode.MENU;
    }
}
