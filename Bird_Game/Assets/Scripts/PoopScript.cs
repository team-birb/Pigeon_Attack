using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScript : MonoBehaviour
{
    public float movementSpeed;

    private CharacterController poopController;
    private GameObject bird;

    void Start()
    {
        bird =  GameObject.Find("Bird");
        poopController = GetComponent<CharacterController>();
        InvokeRepeating("IncreaseSpeed", 1.0f, 1.0f);
    }

    void Update () {
        // Use input to create movement vector.
        Vector3 movementDirection = new Vector3(0, -1 , 1);
        
        // Translate object in the direction of the movement vector.
        poopController.Move(movementDirection * movementSpeed * Time.deltaTime);    
        foreach(GameObject floor in GameObject.FindGameObjectsWithTag("WorldTile"))
        {
            if(Mathf.Abs(transform.position.y - floor.transform.position.y) < 2)
            {
                Destroy(gameObject);
            }
        }
    }

    void IncreaseSpeed()
    {
        movementSpeed = movementSpeed + 1.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        PointCounter pointCounter = bird.GetComponent<PointCounter>();
        
        if (other.CompareTag("Obstacle") && pointCounter != null)
        {
            pointCounter.ObstacleHit();
            Destroy(gameObject);
        }
    }
}
