using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public GameObject PowerUpToEnablePlayerExtraGuns;
    public sbyte PointsForGive;
    private float _enemiesTotalHealth = 100.0f;

    void OnTriggerEnter(Collider _colliderGameObject)
    {
        if (_colliderGameObject.tag == "PlayerBullet")
        {
            Debug.Log("Hit");
            EnemiesTakeDamage(50);
            Destroy(_colliderGameObject.gameObject);

            if (_enemiesTotalHealth <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.RecordPlus(PointsForGive);
                SummonPowerUp();
            }
        }

        if (_colliderGameObject.tag == "Player")
        {
            Destroy(_colliderGameObject.gameObject);
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
