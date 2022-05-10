using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // References
    Transform birdPlayer; // the player
    float distance; // the distance of the player from turret
    public float minDist; // the minimum distance to active the turret
    public Transform head; // the head of the turret 
    public GameObject projectile; // the projectile
    public Transform cannon; // the barrel
    public float shootForce; // the force the projectile is shot
    public float shootRate; // the rate the projectiles are shot
    public float cooldown; // time until next shot
    public AudioSource shootSound; // the sound of the projectile
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        birdPlayer = GameObject.FindGameObjectWithTag("PigeonBird").transform; // player is gameobject with tag PigeonBird
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(birdPlayer.position, transform.position); // distance between bird and turret
        if (distance <= minDist) // if current distance is less than or equal to min dist
        {
            head.LookAt(birdPlayer); // turn the turret towards the bird player
            if (Time.time >= cooldown) // if time is greater than or equal to cooldown
            {
                cooldown = Time.time + 1f / shootRate; // cooldown is time plus 1 divided by the shootrate
                shoot(); // call the shoot function
            }
        }
    }

    // function that shoorts the projectiles
    private void shoot()
    {
        GameObject temp = Instantiate(projectile, cannon.position, head.rotation); // instantiate a temp projectile at position of cannon and rotation of head
        temp.GetComponent<Rigidbody>().AddForce(head.forward * shootForce); // the force the projectile moves forward
        Destroy(temp, destroyTime); // destroy the projectiles after 10 seconds
        shootSound.Play(); // play the shoot sound
    }
}
