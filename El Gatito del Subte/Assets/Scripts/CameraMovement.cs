using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : BaseClass
{
    public Transform player;
    void Update()
    {
        if (player.position.x > 0)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
