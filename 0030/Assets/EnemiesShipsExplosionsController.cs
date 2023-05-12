using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShipsExplosionsController : MonoBehaviour
{

    public AudioSource EnemiesAreAudioSource;
    public AudioClip AudioClipEnemiesExplosion;
    

    void Update()
    {
        if (gameObject != null)
        {
            EnemiesAreAudioSource.PlayOneShot(AudioClipEnemiesExplosion);
        }
    }
}
