using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : BaseClass
{
    public Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
