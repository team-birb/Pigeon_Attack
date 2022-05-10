using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BirdPlayer : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public float timer;
    public HealthBar healthBar;
    public AudioClip clip;
    public AudioSource hitSound;
    public AudioSource hitSound2;
    protected string currentState;
    public AudioSource collectSound;
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Awake()
    {
       Initialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GetDamage(1);
        }

        FlightMovement flightMovement = GetComponent<FlightMovement>();

        if (other.CompareTag("Food") && (currentHealth == maxHealth))
        {
            flightMovement.FoodCollect();
            collectSound.Play();
        } else if (other.CompareTag("Food")) {
            GetDamage(-1);
            collectSound.Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /// If state is in DAMAGED wait 1 sec before receiving more damage
        if (currentState == "DAMAGED")
        {
            Debug.Log("SWITCH DAMAGE");
            timer = timer + 1f * Time.deltaTime;
            if (timer >= 1.0 )
            {
                currentState = "IDLE";
                Debug.Log("SWITCH IDLE");
            }
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            deathSound.Play();
            SceneManager.LoadScene(2); 
           
        }
    }

    public void Initialize() 
    {
        currentHealth = maxHealth;   
        currentState = "IDLE";
        healthBar.SetMaxHealth(maxHealth);
    }

    /// Decrease with damage and updates health value
    void GetDamage (int damage)
    {   
        if(currentState == "IDLE")
        {
            hitSound.clip = clip;
            hitSound.Play(0);
            hitSound2.Play();
            timer = 0f;
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
       
        currentState = "DAMAGED";
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
