using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlightMovement : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;
    public float gravity = -9.81f;
    public float gravityScale;
    public float jumpHeight;
    public GameObject poop;
    public float poopRate;
    public int poopCount;
    
    private CharacterController characterController;
    private float nextPoop = 0.0f;
    private float verticalInput;
    private float horizontalInput;
    private float jumpVelocity;
    private bool isFlying;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        isFlying = true;
        InvokeRepeating("IncreaseSpeed", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Get vertical and horizontal input form user.
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // When play hits the ground change state trigger to not flying
        if(characterController.isGrounded){
            isFlying = false;
        }

        // State trigger for flying and hopping
        if (isFlying) {
            Flying();
        } else {
            Hopping();
        }
    }

    void IncreaseSpeed()
    {
        movementSpeed = movementSpeed + 1.0f;
    }

    void Flying(){

        // Make once per space press but also limit poop to the set rate. 
        if((Time.time > nextPoop) && (poopCount > 0) && Input.GetKeyDown("space"))
        {
            // Update poop rate timer.
            nextPoop = Time.time + poopRate;
            // Decrease the poop ammo
            poopCount--;
            // Instantiate poop object at the bird's position.
            GameObject clone = Instantiate(poop, transform.position + (transform.up*-2), transform.rotation) as GameObject;
        }

        // Use input to create movement vector.
        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput , 1);
        
        // Translate object in the direction of the movement vector.
        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

        // If the object is moving...
        if (movementDirection != Vector3.zero)
        {
            // Create a rotation movement using the movementDirection as the foward.
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            // Rotate object toward the direction determined by toRotation.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

   void Hopping()
    {
        // Update poop rate timer so the bird doesn't poop during state switch. 
        nextPoop = Time.time + poopRate;

        // When space is pressed return to Flying state.
        if(Input.GetKey("space"))
        {
            isFlying = true;
        }

        // Every time the bird hits the ground, reset its jump velocity 
        if (characterController.isGrounded)
        {
            jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
        }
        // After the upward jump, make the bird fall.
        jumpVelocity += gravity * gravityScale * Time.deltaTime;

        // Use input and jumping to create movement vector.
        Vector3 movementDirection = new Vector3(horizontalInput, jumpVelocity, 1);
        // Use input only to create a vector for rotation.
        Vector3 rotationDirection = new Vector3(horizontalInput, 0, 1);
        
        // Translate object in the direction of the movement vector.
        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
        
        // If the object is moving...
        if (movementDirection != Vector3.zero)
        {
            // Create a rotation movement using the rotationDirection as the foward.
            Quaternion toRotation = Quaternion.LookRotation(rotationDirection, Vector3.up);
            // Rotate object toward the direction determined by toRotation.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void FoodCollect(){
        poopCount++;
    }
}