using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Player;
    public GameObject MenuGameOver;
    public Transform PlayerHealthBar;
    public GameObject PlayerHealthBarFullStatusGameObject;
    private Vector3 _playerHealthBarScale;
    private float _playerHealthPercent;
    public float _playerHealth;
    public bool PlayerLasersAreEnabled;
    public GameObject MarsManager;

    void Start()
    {
        _playerHealth = 100.0f;
        _playerHealthBarScale = PlayerHealthBarFullStatusGameObject.transform.localScale;
        _playerHealthPercent = _playerHealthBarScale.x / _playerHealth;
        PlayerLasersAreEnabled = Player.GetComponent<PlayerGuns>().PlayerLasersAreEnabled;

    }

    void PlayerUpdateHealthBar()
    {
        _playerHealthBarScale.x = _playerHealthPercent * _playerHealth;
        PlayerHealthBarFullStatusGameObject.transform.localScale = _playerHealthBarScale;
    }

    void OnTriggerEnter(Collider _enemiesCollider)
    {
        if (_enemiesCollider.tag == "EnemiesBullet")
        {
            Destroy(_enemiesCollider.gameObject);
            _playerHealth -= 20;
            PlayerUpdateHealthBar();

            if (_playerHealth <= 0 || _enemiesCollider.tag == "Enemy")
            {
                Destroy(gameObject);
                MenuGameOver.SetActive(true);
            }

            if (MarsManager.GetComponent<GameManager>().PlayerScore >= 0)
            {
                Debug.Log("Diminuiu a pontuação?");
                MarsManager.GetComponent<GameManager>().PlayerScore -= 50;
            }

            /*if (PlayerLasersAreEnabled == true)
            {
                PlayerLasersAreEnabled = false;
            }*/
        }
    }
}


/*   public void ganharVida(float VidaParaReceber) //Recebendo vida
   {
       if (vidaPlayerAtual + VidaParaReceber <= vidaPlayer)
       {
           vidaPlayerAtual = VidaParaReceber;
       }
       else
       {
           vidaPlayerAtual = vidaPlayer;
       }

       PlayerHealthBar.value = vidaPlayerAtual;
   }
*/