using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip coinSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.sharedInstance.CollectCoin();
            AudioSource.PlayClipAtPoint(coinSound,transform.position);
            Destroy(gameObject);
        }
    }
}
