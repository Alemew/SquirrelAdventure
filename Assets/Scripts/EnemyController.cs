using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * rol 4
 * Los cactus están inmóviles en el escenario pero los enemigos andarán hacia la izquierda a un
 * ritmo lento y aleatorio, y se acabarán cayendo al KillTrigger donde serán destruidos.

 */

public class EnemyController : MonoBehaviour
{
    public static EnemyController sharedInstance;
    private Rigidbody2D _rigidbody2D;
    public BoxCollider2D _boxcollider2D;
    public float runningSpeed = -2.0f;//velocidad
    private Vector3 startPosition;
    public AudioClip  coinSound;

    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState==GameState.inTheGame)
        {
            if (_rigidbody2D.velocity.x<runningSpeed)
            {
                _rigidbody2D.velocity = new Vector2(-runningSpeed, _rigidbody2D.velocity.y);
                //_rigidbody2D.velocity = Vector2.right * runningSpeed;
            }
        }
        
    }
    //rol 5 6
    private void OnTriggerEnter2D(Collider2D other) //si paso a traves de un enemigo
    {
        if (other.gameObject.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(coinSound,transform.position);
            
            if (GameManager.sharedInstance.collectCoin==0)
            {
                if (!RandomSpawner.sharedInstance.superpower)
                {
                PlayerController.sharedInstance.KillPlayer();
                }
            }
            
            if (GameManager.sharedInstance.collectCoin>0)// si tengo mas de 0 monedas las pongo a cero
            {
                if (!RandomSpawner.sharedInstance.superpower)
                {
                    GameManager.sharedInstance.DeleteCoin();
                    PlayerController.sharedInstance.animator.Play("Tirar");
                    this._boxcollider2D.enabled = false;
                }
            }
            
        }
    }

    private void Awake()
    {
        startPosition = this.transform.position;
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        sharedInstance = this;

    }

    // Start is called before the first frame update
    public void StartGame()
    {
       
        this.transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
   
}
