using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdCamera : MonoBehaviour
{
    public Transform bird;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - bird.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")) Application.Quit();
        if (Input.GetKeyDown(KeyCode.LeftShift)) SceneManager.LoadScene(0);
        transform.position = bird.position + offset;
    }
}
