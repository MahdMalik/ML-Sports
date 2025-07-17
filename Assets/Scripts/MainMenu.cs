using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameObject menuScreen;
    private GameObject creditScreen;
    private GameObject gameScreen;

    [SerializeField]
    private BaseballGame game;

    void Awake()
    {
        menuScreen = transform.Find("MainMenu").gameObject;
        creditScreen = transform.Find("Credits").gameObject;
        gameScreen = transform.Find("Games").gameObject;
    }

    void OnEnable()
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
        //set the entire UI inactive
        gameScreen.transform.parent.gameObject.SetActive(false);
        game.gameObject.SetActive(true);
        Debug.Log("GAME STARTING!");
    }
    
}
