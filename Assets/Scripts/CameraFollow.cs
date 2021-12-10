using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float separation= 6.66f;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + separation, transform.position.y,
            transform.position.z);
    }
}
