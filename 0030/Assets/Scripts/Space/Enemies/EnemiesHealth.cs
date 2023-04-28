using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public GameObject PowerUpToEnablePlayerExtraGuns;
    public sbyte PointsForGive;
    private float _enemiesTotalHealth = 100.0f;
    public GameObject CanvasMenuGameOver;

    void OnCollisionEnter(Collision _colliderGameObject)
    {
        if (_colliderGameObject.gameObject.tag == "PlayerBullet")
        {
            EnemiesTakeDamage(50);

            if (_enemiesTotalHealth <= 0)
            {
                GameManager.Instance.RecordPlus(PointsForGive);
                SummonPowerUp();
                Destroy(gameObject);
            }
        }

        if (_colliderGameObject.gameObject.tag == "Player")
        {
            Destroy(_colliderGameObject.gameObject);
            CanvasMenuGameOver.gameObject.SetActive(true);

        }
    }

    public void EnemiesTakeDamage(int _damageFromThePlayer)
    {
        _enemiesTotalHealth -= _damageFromThePlayer;
        if (_enemiesTotalHealth <= 0)
            Destroy(gameObject);
    }

    void SummonPowerUp()
    {
        int _chanceToDropPowerUpPlayerExtraGuns = Random.Range(0, 10);
        if (_chanceToDropPowerUpPlayerExtraGuns >= 8)
        {
            GameObject PowerUpExtraGunsPlayer = Instantiate(PowerUpToEnablePlayerExtraGuns, transform.position, transform.rotation);
            Vector3 powerUpMovement = PowerUpExtraGunsPlayer.transform.up;
            PowerUpExtraGunsPlayer.GetComponent<Rigidbody>().velocity = powerUpMovement;
        }
    }
}
