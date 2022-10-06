using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip impactSound;
    private AudioSource audioSource;
    private Rigidbody ballRB;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float volume = ballRB.velocity.magnitude / 10;
        audioSource.PlayOneShot(impactSound, volume);
    }
}
