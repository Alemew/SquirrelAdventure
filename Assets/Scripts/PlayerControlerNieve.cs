using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerNieve : MonoBehaviour
{
    //rol 3
    /*Cuando estás corriendo sobre un suelo con nieve tu velocidad decrece a la mitad (más o menos, calcula una velocidad medianamente jugable).
    Al pisar un suelo normal, vuelve la velocidad del protagonista a la que tenía antes de pisarlo.
    */
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.sharedInstance.CollectCoin();
        PlayerController.sharedInstance.runningSpeed /= 2;
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        GameManager.sharedInstance.CollectCoin();
        PlayerController.sharedInstance.runningSpeed *= 2;
    }
    
}
