using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBullet : MonoBehaviour
{
    private Rigidbody _playerBulletRigidbody;

    void Start()
    {
        Destroy(gameObject, 3f);
    }
}
