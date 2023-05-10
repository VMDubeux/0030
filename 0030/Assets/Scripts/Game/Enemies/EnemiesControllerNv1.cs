using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllerNv1 : MonoBehaviour
{
    public float EnemySpeed = 15.0f;

    void Start()
    {
 
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x -= EnemySpeed * Time.fixedDeltaTime;
        position.z = 7;
        transform.position = position;

        DestroyGameObject(position); //Destrói objeto após passar determinada área
    }

    private void DestroyGameObject(Vector3 position) //Método destrói inimigo
    {
        if (position.x < -18)
            Destroy(gameObject);
    }
}
