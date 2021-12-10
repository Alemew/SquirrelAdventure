using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameOverCanvas : MonoBehaviour
{
    public static UpdateGameOverCanvas sharedInstance;
    
    public Text coinsNumber;
    public Text scorePoints;


    private void Awake()
    {
        sharedInstance = this;
    }

    public void SetScorePointsAndCoins()
    {
        coinsNumber.text = GameManager.sharedInstance.collectCoin.ToString();
        scorePoints.text = PlayerController.sharedInstance.GetDistanceTravelled().ToString("f0");
    }
}
