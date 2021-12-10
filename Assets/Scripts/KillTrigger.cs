using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
   public AudioClip hitSound;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         AudioSource.PlayClipAtPoint(hitSound,transform.position);
         PlayerController.sharedInstance.KillPlayer();
      }
   }
}
