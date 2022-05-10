using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TileManager detects if player has left an old tile, calls the spawn tile function and destroys old tiles
public class TileManager : MonoBehaviour
{
    TileSpawner tileSpawner; // This variable is of type TileSpawner script
    public int lifetime; // How long until the tile despawns

    // Start is called before the first frame update
    void Start()
    {
        tileSpawner = GameObject.FindObjectOfType<TileSpawner>(); // at the start of the game call the tilespawner script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when player exits the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PigeonBird")
        {
            tileSpawner.spawnTiles(); // call spawnTiles function from TileSpawner
            Destroy(gameObject, lifetime); // destroy the tile after 10 seconds
        }
        
    }
}
