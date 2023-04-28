using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSuicide : MonoBehaviour
{
    public Transform Player;
    public float EnemySpeed = 0.1f;
    private Vector3 targetPosition;
    private bool enemyLook;


    void FixedUpdate()
    {
        targetPosition = Player.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemySpeed * Time.fixedDeltaTime);

        enemyLook = targetPosition.x - transform.position.x >= 0;

        if (enemyLook == true)
        {
            transform.rotation = Quaternion.Euler(-90f, -180f, -90f);

        }

        if (enemyLook == false)
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, -90);
        }
    }
}
