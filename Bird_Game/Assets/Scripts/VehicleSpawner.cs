using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public List<GameObject> vehiclePrefabs = new List<GameObject>(); // list of vehicle obstacles
    public Transform spawnPoint; // the initial spawn point
    public float timer = 0f; // the timer that starts at 0
    public float countdown; // how long until next spawn
    private int randomNum; // variable to pick random vehicle

    // Start is called before the first frame update
    void Start()
    {
        spawnVehicle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= countdown) // timer until next vehicle spawn
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnVehicle();
        }
    }

    void spawnVehicle()
    {
        randomNum = Random.Range(0, vehiclePrefabs.Count); // pick a random number from the list of vehicle prefabs
        Instantiate(vehiclePrefabs[randomNum], spawnPoint.position, transform.rotation); // spawn the random vahicle
    }
}
