using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsActivateExtraGuns : MonoBehaviour
{
    public GameObject Player;
    public bool PlayerLasersAreEnabled = false;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter(Collision _colliderGameObject)
    {
        if (_colliderGameObject.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerGuns>().PlayerLasersSpawnPoint[0].gameObject.SetActive(true);
            Player.GetComponent<PlayerGuns>().PlayerLasersSpawnPoint[1].gameObject.SetActive(true);
            PlayerLasersAreEnabled = true;
        }
        Destroy(gameObject);
    }
}