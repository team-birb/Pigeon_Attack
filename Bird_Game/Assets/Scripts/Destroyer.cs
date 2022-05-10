using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroyer despawns obstacle prefabs after a set amount of time
public class Destroyer : MonoBehaviour
{
    public float lifetime; // How long to wait until the objects

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); // destroy the gameObject after set time
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
