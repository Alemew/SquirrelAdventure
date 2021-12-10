using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 20.0f;//fuerza de salto
    private Rigidbody2D _rigidbody2D;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runningSpeed = 2.0f;//velocidad
    public static PlayerController sharedInstance;
    private Vector3 startPosition;
    public float distanceTravelled;
    private float multiplo = 100f;//tarea 2
    public GameObject elipse;

    public float GetDistanceTravelled()
    
    
    {
        distanceTravelled = Vector2.Distance(new Vector2(startPosition.x, 0), new Vector2(transform.position.x, 0));
        
        if(distanceTravelled > multiplo && LevelGenerator.sharedInstance.allTheLevelBlocks.Count<16)
        {
            multiplo += 100;
            //Debug.Log("hola");
            //tarea 1
            LevelGenerator.sharedInstance.AddNewBlockAll();
            //tarea 2
            runningSpeed+=+1f;//Cada 100 puntos en nuestro marcador aumentará un poco la velocidad de nuestro protagonista y también subirá su gravedad ligeramente.
            jumpForce -=0.5f;//y también subirá su gravedad ligeramente.
        }
        return distanceTravelled;
    }
    
    public void KillPlayer()
    {
        animator.SetBool("isALive",false);
        
        Invoke("DelayGameOver", 1f);//tiempo para ponerlo a dormir
        if (PlayerPrefs.GetFloat("highscore",0) < GetDistanceTravelled())
        {
            PlayerPrefs.SetFloat("highscore",GetDistanceTravelled());
        }
    }

    public void DelayGameOver()
    {
        GetComponent<Rigidbody2D>().Sleep();//pongo a dormir el muñeco
        GameManager.sharedInstance.GameOver();
    }

    private void Awake()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        sharedInstance = this;
        startPosition = this.transform.position;
        animator.SetBool("isALive",true);
    }
    
    public void StartGame()
    {
        animator.SetBool("isALive",true);
        this.transform.position = startPosition;
    }

    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            if (_rigidbody2D.velocity.x<runningSpeed)
            {
                _rigidbody2D.velocity = new Vector2(runningSpeed, _rigidbody2D.velocity.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGrounded",isOnTheFloor());


        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
            {
                if (isOnTheFloor())
                {
                    jump();
                    GetComponent<AudioSource>().Play();
                    animator.SetBool("isGrounded",false);
                }
                
            }
            
        }
    }

    void jump()
    {
        
        _rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
    }

    bool isOnTheFloor()
    {
        bool isOnTheFloor = false;
        if (Physics2D.Raycast(this.transform.position,Vector2.down,1.0f,groundLayerMask.value))
        {
            isOnTheFloor = true;
        }

        return isOnTheFloor;
    }

}
