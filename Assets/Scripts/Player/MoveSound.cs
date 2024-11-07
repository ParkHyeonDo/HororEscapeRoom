using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSound : MonoBehaviour
{
    public AudioClip MoveSoundClip;
    private AudioSource audioSource;
    private Rigidbody _rigidbody;
    public float footstepThreshold;
    public float footstepRate;
    private float footStepTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MoveSoundClip;
    }

    private void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.1f)
        {
            if (_rigidbody.velocity.magnitude > footstepThreshold)
            {
                if (Time.time - footStepTime > footstepRate)
                {
                    float speed = GameManager.Instance.Player.Controller.RigidBody.velocity.magnitude;
                    footStepTime = Time.time;
                    if(speed > 3f)
                    {
                        audioSource.Play();
                        footstepRate = 0.5f;
                    }
                    else if(speed > 1f)
                    {
                        audioSource.Play();
                        footstepRate = 1f;
                    }
                    else
                    {
                        audioSource.Stop();
                    }
                }
            }
        }
    }
}
