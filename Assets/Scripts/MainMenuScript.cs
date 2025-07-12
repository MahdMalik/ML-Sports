using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject creditScreen;
    public GameObject gameScreen;

    void Start()
    {
        menuScreen.SetActive(true);
        creditScreen.SetActive(false);
        gameScreen.SetActive(false);
    }

    public void BackButton(GameObject buttonClicked)
    {
        GameObject parentScreen = buttonClicked.transform.parent.gameObject;
        menuScreen.SetActive(true);
        parentScreen.SetActive(false);
    }

    public void ToCreditsButton()
    {
        menuScreen.SetActive(false);
        creditScreen.SetActive(true);
    }

    public void ToGamesButton()
    {
        gameScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void StartBaseballGame()
    {
        gameScreen.SetActive(false);
        Debug.Log("GAME STARTING!");
    }
}
