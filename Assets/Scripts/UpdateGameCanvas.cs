using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameCanvas : MonoBehaviour
{

    public static UpdateGameCanvas sharedInstance;
    
    public Text coinsNumber;
    public Text scorePoints;
    public Text recordPoints;
    
    
    private void Awake()
    {
        sharedInstance = this;
    }

    public void SetRecordPoints()
    {
        recordPoints.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
    }

    public void SetCoinsNumber()
    {
        coinsNumber.text = GameManager.sharedInstance.collectCoin.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            scorePoints.text = PlayerController.sharedInstance.GetDistanceTravelled().ToString("f0");
        }
    }
}
