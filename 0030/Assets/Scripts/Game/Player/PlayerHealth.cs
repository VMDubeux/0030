using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Player;
    public Canvas CanvasMenuGameOver;
    public Transform PlayerHealthBar;
    public GameObject PlayerHealthBarFullStatusGameObject;
    private Vector3 _playerHealthBarScale;
    private float _playerHealthPercent;
    public float _playerHealth;
    public bool PlayerLasersAreEnabled;
    public GameObject Timer;

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

    void OnCollisionEnter(Collision _damageFromTheEnemies)
    {
        if (_damageFromTheEnemies.gameObject.tag == "EnemiesBullet")
        {
            _playerHealth -= 20;
            PlayerUpdateHealthBar();

            if (_playerHealth <= 0)
            {
                Timer.gameObject.SetActive(false);
                CanvasMenuGameOver.gameObject.SetActive(true);
                Destroy(gameObject);
            }
           
            if (_damageFromTheEnemies.gameObject.tag == "Enemy")
            {
                CanvasMenuGameOver.gameObject.SetActive(true);
                Destroy(gameObject);
            }

            Destroy(_damageFromTheEnemies.gameObject);
            GameManager.Instance.RecordPlus(-50);
            
            if (PlayerLasersAreEnabled == true)
            {
                PlayerLasersAreEnabled = false;
            }
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