using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Control : MonoBehaviour
{
    public Transform Player;
    public float yOffset = 3.0f;
    public float zOffset = 10.0f;
    public float xOffset = 10.0f;
    Vector3 newPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        newPos = Player.position;
        newPos.y = newPos.y + yOffset;
        newPos.z = newPos.z + zOffset;
        newPos.x = newPos.x + xOffset;
        transform.position = newPos;
        transform.LookAt(Player.position);
    }
}
