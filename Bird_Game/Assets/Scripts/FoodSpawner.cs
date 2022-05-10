using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // the references
    public float xSize = 20.0f; // size of x-axis from -25 to 25
    public float ySize = 4.0f; // size of y-axis
    public float zSize = 60.0f; // size of z-axis from -64 to 64

    public Transform spawnPoint; // the initial spawn point
    public GameObject newFood; // the new food prefab
    public Vector3 newFoodPosition; // the position where the new food should spawn

    public List<GameObject> foodPrefabs = new List<GameObject>(); // the list of food prefab objects
    private int randomNum; // variable to pick random food

    // Start is called before the first frame update
    void Start()
    {
        AddNewFood(); // spawn a new food when a new tile is created
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function to spawn new food
    void AddNewFood()
    {
        RandomPosition(); // call the function to pick a random position
        randomNum = Random.Range(0, foodPrefabs.Count); // pick a random number from the list of food prefabs
        newFood = GameObject.Instantiate(foodPrefabs[randomNum], newFoodPosition, Quaternion.identity) as GameObject; // Instantiate a random dessert in a random coordinate
    }

    // function to pick a random coordinate in random x and z coordinate, y is constant
    void RandomPosition()
    {
        newFoodPosition = spawnPoint.position; // make newFoodPosition the spawnPoint
        newFoodPosition.x += Random.Range(-xSize, xSize); // spawn in a random x position
        newFoodPosition.y += ySize;
        newFoodPosition.z += Random.Range(-zSize, zSize); // spawn in a random z position
    }
}
