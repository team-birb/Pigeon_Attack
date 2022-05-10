using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TileSpawner spawns the new tiles, put into an empty gameobject called TileSpawner 
public class TileSpawner : MonoBehaviour
{
    public List<GameObject> tilePrefab = new List<GameObject>(); // The different street, avenue or road tile prefabs
    Vector3 nextTileSpawn; // The spawn point of the next tile
    private int randInt; // A random int
    private int oldInt; // The previous random int
    

    // Start is called before the first frame update
    void Start()
    {
        spawnStartTile(); // Spawn 3 street tiles initially
        spawnStreetTile();
        spawnStreetTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // spawnTiles() spawns 3 street tiles followed by 1 avenue tile
    public void spawnTiles()
    {
        // need to following to prevent consecutive repeating random int
        randInt = Random.Range(0, 4); // Random int from 0-3
        while (oldInt == randInt) // While old and new rand int are the same
        {
            randInt = Random.Range(0, 4); // Get a new rand int
        }
        oldInt = randInt; // Update old int

        if (randInt == 3) // if rand int = 3
        {
            spawnAvenueTile(); // spawn an avenue tile
        }
        else
        {
            spawnStreetTile(); // else spawn a street tile
        } 
    }

    // spawnStartTile() spawns street tile prefab without obstacles
    public void spawnStartTile()
    {
        GameObject tempStreet = Instantiate(tilePrefab[0], nextTileSpawn, Quaternion.identity); // Spawn a street tile without obstacles
        nextTileSpawn = tempStreet.transform.GetChild(0).transform.position; // The next spawn point is the 0th child of StartTile
    }

    // spawnStreetTile() spawns street tile prefab
    public void spawnStreetTile()
    {
        GameObject tempStreet = Instantiate(tilePrefab[1], nextTileSpawn, Quaternion.identity); // Spawn a street tile at the next tile spawn point without rotation
        nextTileSpawn = tempStreet.transform.GetChild(0).transform.position; // The next spawn point is the 0th child of StreetTile
    }

    // spawnAvenueTile() spawns avenue tile prefab
    public void spawnAvenueTile()
    {
        GameObject tempAvenue = Instantiate(tilePrefab[2], nextTileSpawn, Quaternion.identity); // Spawn an avenue tile at the next tile spawn point without rotation
        nextTileSpawn = tempAvenue.transform.GetChild(0).transform.position; // The next spawn point is the 0th child of AvenueTile
    }
}
