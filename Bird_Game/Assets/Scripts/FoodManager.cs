using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // the references
    public float spinSpeed = 100f; // The speed the foods rotate

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.Self); // Spin the food objects along its y-axis
    }

    // function to detect if the bird player has collected a food item
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PigeonBird")) // if pigeon bird collides with the food
        {
            Destroy(gameObject); // destroy the food
        }
    }
}
