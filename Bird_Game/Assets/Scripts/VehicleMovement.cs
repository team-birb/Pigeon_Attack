using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float moveSpeedMin; // the minimum speed the vehicle should move
    public float moveSpeedMax; // the maximum speed the vehicle should move
    public float moveSpeed; // the move speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax); // random move speed between min and max
        transform.position += transform.forward * moveSpeed * Time.deltaTime; // move the vehicle by the movespeed
    }

}
