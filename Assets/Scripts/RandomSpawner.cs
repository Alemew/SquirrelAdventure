using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    
    
    /**
     * El ítem de estrella será instanciado por código en el escenario en un
     * sitio más o menos aleatorio (por delante de donde va la cámara) y
     * cada 200 puntos.
     */
    public GameObject ItemPrefab;

    public float Radius = 1;
    
    public AudioClip coinSound;
    private int multiplo = 200;
    private float distanciaFinal = 0;
    public bool superpower = false;

    public static RandomSpawner sharedInstance;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        distanciaFinal = PlayerController.sharedInstance.distanceTravelled;
        if (other.tag == "Player")
        {
            GameManager.sharedInstance.CollectCoin();
            AudioSource.PlayClipAtPoint(coinSound,transform.position);
            
            while (distanciaFinal + 100 > PlayerController.sharedInstance.distanceTravelled)
            {
                PlayerController.sharedInstance.elipse.SetActive(true);
                superpower = true;
            }
            PlayerController.sharedInstance.elipse.SetActive(false);
            superpower = false;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(" randomspawner "+ GameManager.sharedInstance.collectCoin);
        if (PlayerController.sharedInstance.distanceTravelled > multiplo)//si tengo 200 puntos o multiplo  aparezco
        {
            SpawnObjectAtRandom();
            multiplo += 200;
        }
        
        
    }

    void SpawnObjectAtRandom()
    {
        
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomPos += new Vector3(this.transform.position.x, 0, 0); 
        Instantiate(ItemPrefab, randomPos, Quaternion.identity);
        Debug.Log(randomPos);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }*/
}