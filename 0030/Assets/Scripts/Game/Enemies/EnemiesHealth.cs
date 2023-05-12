using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PowerUpToEnablePlayerExtraGuns;
    public sbyte PointsForGive;
    private float _enemiesTotalHealth = 100.0f;

    void OnTriggerEnter(Collider _colliderGameObject)
    {
        if (_colliderGameObject.tag == "PlayerBullet")
        {
            Debug.Log("Hit");
            _enemiesTotalHealth -= 50.0f;
            Destroy(_colliderGameObject.gameObject);

            if (_enemiesTotalHealth <= 0.0f)
            {
                Destroy(gameObject);
                GameManager.Instance.RecordPlus(PointsForGive);
                SummonPowerUp();
                ExplodeEnemyShip();
            }
        }

        if (_colliderGameObject.tag == "Player")
        {
            Destroy(_colliderGameObject.gameObject);
        }
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

    void ExplodeEnemyShip()
    {
        GameObject ExplosionFX = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(ExplosionFX, 0.75f);
    }
}
