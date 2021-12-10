using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    /**
     * 10. Desarrolla la funcionalidad de que el juego se
     * pueda pausar al pulsar en un botón “Pausa” del
     * gameCanvas y que al volver a darle al botón
     * volvamos a la partida
     */
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject botonContinue;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
            
        }
    }


    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        botonContinue.SetActive(true);
        
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        botonContinue.SetActive(false);
    }

}