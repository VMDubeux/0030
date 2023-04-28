using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody _playerBulletRigidbody;

    void Start()
    {
        Destroy(gameObject, 1.1f);
    }
}