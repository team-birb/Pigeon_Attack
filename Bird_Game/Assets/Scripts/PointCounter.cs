using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointCounter : MonoBehaviour
{
    public int points;
    public AudioClip clip;
    public AudioSource sound;

    public UnityEvent<PointCounter> OnObstacleHit;

    public void ObstacleHit(){
        points+=5;
        sound.clip = clip;
        sound.Play(0);
        OnObstacleHit.Invoke(this);
    }
}
