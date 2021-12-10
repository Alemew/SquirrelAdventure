using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private float tiempo;
    private void OnCollisionEnter2D(Collision2D other) //lo toca y se activa
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("jugador toco");
        }
    }

    private void OnCollisionStay2D(Collision2D other)// lo esta tocando
    {
        if (other.collider.CompareTag("Player"))
        {
            tiempo += Time.deltaTime;
            Debug.Log("jugador tocando el enemigo");
        }
    }

    private void OnCollisionExit2D(Collision2D other)// lo deja de tocar
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("jugador salió" + tiempo);
            tiempo = 0;
        }
    }
}