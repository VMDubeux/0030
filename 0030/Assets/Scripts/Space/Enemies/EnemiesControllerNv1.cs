using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllerNv1 : MonoBehaviour
{
    public float EnemySpeed = 65.0f;

    void Start()
    {
        EnemyGenerator();
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x -= EnemySpeed * Time.fixedDeltaTime;
        transform.position = position;

        DestroyGameObject(position); //Destrói objeto após passar determinada área
    }

    private void EnemyGenerator() //Método gerador de inimigo
    {
        int _enemyGenerator = 1;
        transform.GetChild(_enemyGenerator).gameObject.SetActive(true);
    }

    private void DestroyGameObject(Vector2 position) //Método destrói inimigo
    {
        if (position.x < -400)
            Destroy(gameObject);
    }
}
