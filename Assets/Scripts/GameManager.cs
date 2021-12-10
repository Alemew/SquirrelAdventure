using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inTheGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;

    public static GameManager sharedInstance;

    public Canvas MenuCanvas;
    public Canvas GameCanvas;
    public Canvas GameOverCanvas;
    public int collectCoin=0;

    public void CollectCoin()
    {
        collectCoin++;
        UpdateGameCanvas.sharedInstance.SetCoinsNumber();
    }
    
    
    //rol 5 pone las monedas a 0
    public void DeleteCoin()
    {
        this.collectCoin = 0;
        UpdateGameCanvas.sharedInstance.SetCoinsNumber();
    }
    
    private void Awake()
    {
        sharedInstance = this;
    }

    public void StartGame()
    {
        collectCoin = 0;
        ChangeStateGame(GameState.inTheGame);
        UpdateGameCanvas.sharedInstance.SetCoinsNumber();
        PlayerController.sharedInstance.StartGame();
        LevelGenerator.sharedInstance.GenerateInitialBLocks();
        UpdateGameCanvas.sharedInstance.SetRecordPoints();
    }

    public void GameOver()
    {
        ChangeStateGame(GameState.gameOver);
        LevelGenerator.sharedInstance.RemoveAllTheBlocks();
        UpdateGameOverCanvas.sharedInstance.SetScorePointsAndCoins();
        
    }
    
    public void BackToMainMenu()
    {
        ChangeStateGame(GameState.menu);
    }
    
    void Start()
    {
        currentGameState = GameState.menu;
        MenuCanvas.enabled = true;
        GameCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        MenuCanvas.GetComponent<AudioSource>().Play();
        GameCanvas.GetComponent<AudioSource>().Stop();
        GameOverCanvas.GetComponent<AudioSource>().Stop();
    }

    void ChangeStateGame(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            currentGameState = GameState.menu;
            MenuCanvas.enabled = true;
            GameCanvas.enabled = false;
            GameOverCanvas.enabled = false;
            MenuCanvas.GetComponent<AudioSource>().Play();
            GameCanvas.GetComponent<AudioSource>().Stop();
            GameOverCanvas.GetComponent<AudioSource>().Stop();
            
        }
        else if (newGameState == GameState.inTheGame)
        {
            currentGameState = GameState.inTheGame;
            MenuCanvas.enabled = false;
            GameCanvas.enabled = true;
            GameOverCanvas.enabled = false;
            MenuCanvas.GetComponent<AudioSource>().Stop();
            GameCanvas.GetComponent<AudioSource>().Play();
            GameOverCanvas.GetComponent<AudioSource>().Stop();
        }
            else
            {
                currentGameState = GameState.gameOver; 
                MenuCanvas.enabled = false;
                GameCanvas.enabled = false;
                GameOverCanvas.enabled = true;
                MenuCanvas.GetComponent<AudioSource>().Stop();
                GameCanvas.GetComponent<AudioSource>().Stop();
                GameOverCanvas.GetComponent<AudioSource>().Play();
            }
    }
    

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            if (currentGameState != GameState.inTheGame)
            {
                Debug.Log("Comienzo");
                StartGame();
            }
        }*/
    }
}
