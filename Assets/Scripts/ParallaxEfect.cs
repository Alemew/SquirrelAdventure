using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfect : MonoBehaviour
{
    /**
     * Los fondos del juego actual son estáticos,
     * sería interesante que esos fondos se movieran a
     * velocidades distintas para aumentar la sensación
     * de profundidad y velocidad. En lo que se conoce
     * como efecto PARALLAX
     */
    [SerializeField] private float parallacMultiplier;

    private Transform cameraTransform;

    private Vector3 previusCameraPosition;

    private float spriteWidth,startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previusCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;//para saber el ancho del sprite
        startPosition = transform.position.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previusCameraPosition.x) * parallacMultiplier; //tanto por ciento de movimiento frente a la camara
        float moveAmount = cameraTransform.position.x * (1 - parallacMultiplier);//cuanto se movió la camara respecto a la capa
        transform.Translate(new Vector3(deltaX,0,0));
        previusCameraPosition = cameraTransform.position;
        if (moveAmount>startPosition+spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth,0,0));
            startPosition += spriteWidth;
        }
    }
}