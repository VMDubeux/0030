using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGuns : MonoBehaviour
{
    public Transform EnemiesBulletSpawnPoint;
    public GameObject EnemiesNormalBulletPrefab;
    public AudioSource EnemiesAreAudioSource;
    public AudioClip EnemiesAudioShoot;
    public float EnemiesBulletSpeed = 200f;
    public float EnemiesFireRate = 5f;
    private float _enemiesNextShoot = 0.0f;

    void Update()
    {
        if (Time.time > _enemiesNextShoot)
        {
            _enemiesNextShoot = Time.time + EnemiesFireRate;
            var _enemiesBullet = Instantiate(EnemiesNormalBulletPrefab, EnemiesBulletSpawnPoint.position, EnemiesBulletSpawnPoint.rotation);
            _enemiesBullet.GetComponent<Rigidbody>().velocity = EnemiesBulletSpawnPoint.right * EnemiesBulletSpeed * -1.0f;
            EnemiesAreAudioSource.PlayOneShot(EnemiesAudioShoot);
        }
    }
}
