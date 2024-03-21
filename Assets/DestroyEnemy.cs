using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DestroyEnemy : NetworkBehaviour
{
    public AudioClip collisionSound; 
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [ServerCallback]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ScoreManager.instance.AddScore(50);
            SoundManager.instance.PlaySound(collisionSound);
            NetworkServer.Destroy(collision.gameObject);
            NetworkServer.Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(-500);
            SoundManager.instance.PlaySound(collisionSound);
            NetworkServer.Destroy(gameObject);
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}


