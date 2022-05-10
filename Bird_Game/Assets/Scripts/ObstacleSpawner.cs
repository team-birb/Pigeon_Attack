using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ObstaccleSpawner to replace the spawners in DetectGroundTile
// ObstacleSpawner spawns the different obstacle prefabs
public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs = new List<GameObject>(); // list of obstacle prefab game objects
    public Transform spawnPoint; // the initial spawn point
    Vector3 spawnOffset; // the spawnpoint with some offset
    private int randomNum; // a random number

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // spawnObstacle() spawns a random obstacle from the list with slight variance
    void spawnObstacle()
    {
        spawnOffset = spawnPoint.position; // make spawnOffset the spawnPoint
        spawnOffset.z += Random.Range(-60f, 60f); // can spawn up to 60 units before or after the initial spawn point
        randomNum = Random.Range(0, obstaclePrefabs.Count); // pick a random number from 0 to count of obstacles
        Instantiate(obstaclePrefabs[randomNum], spawnOffset, Quaternion.identity); // spawn the obstacle prefab at the psawn offset
    }
}
