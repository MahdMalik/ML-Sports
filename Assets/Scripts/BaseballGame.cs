using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballGame : MonoBehaviour
{
    [SerializeField]
    MainMenu theMenu;
    private float lastEventsTime;

    private bool ballBeingThrown;

    private float timeUntilNextPitch;

    private float strikes;

    private float timeUntilPitchEnds;

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("LET'S GOOO!!");
        strikes = 0;
        SetupNextPitch();
    }

    void SetupNextPitch()
    {
        lastEventsTime = Time.time;
        ballBeingThrown = false;
        timeUntilNextPitch = lastEventsTime + Random.Range(3, 10);
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (ballBeingThrown)
        {
            if (currentTime >= timeUntilPitchEnds)
            {
                Debug.Log("Strike!");
                ballBeingThrown = false;
                strikes++;
                if (strikes == 3)
                {
                    EndGame();
                    Debug.Log("Game Over!");
                }
                else
                {
                    SetupNextPitch();
                }
            }
        }
        else
        {
            if (currentTime >= timeUntilNextPitch)
            {
                Debug.Log("Pitching!");
                timeUntilPitchEnds = currentTime + 2;
                ballBeingThrown = true;
            }
        }
    }

    void EndGame()
    {
        gameObject.SetActive(false);
        theMenu.gameObject.SetActive(true);
    }
}
