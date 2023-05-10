using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [Header("Normal Guns: Bullets")]
    public Transform[] PlayerBulletSpawnPoint;
    public GameObject PlayerNormalBulletPrefab;
    public AudioSource PlayerIsAudioSource;
    public AudioClip PlayerAudioShoot;
    public float PlayerBulletSpeed = 50f;
    public float PlayerFireRateKeyX = 0.15f;
    private float _playerNextShoot = 0.0f;

    [Header("Extra Guns: Laser")]
    public Transform[] PlayerLasersSpawnPoint;
    public GameObject PlayerLasersPrefab;
    public AudioSource PlayerIsAudioSourceLaser;
    public AudioClip PlayerAudioShootLaser;
    public float PlayerLaserSpeed = 500f;
    public bool PlayerLasersAreEnabled = false;

    private void Start()
    {

    }

    void Update()
    {
        StartCoroutine(PlayerShootingInputWithSpace());

        if (Input.GetKey(KeyCode.X) && Time.time > _playerNextShoot && !Input.GetKeyDown(KeyCode.Space))
        {
            _playerNextShoot = Time.time + PlayerFireRateKeyX;
            var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[1].position, PlayerBulletSpawnPoint[1].rotation);
            _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[1].right * PlayerBulletSpeed;
            PlayerIsAudioSource.PlayOneShot(PlayerAudioShoot);

            if (PlayerLasersAreEnabled == true)
            {
                PlayerIsAudioSourceLaser.PlayOneShot(PlayerAudioShootLaser);

                for (int j = 0; j < PlayerBulletSpawnPoint.Length; j++)
                {
                    var _playerLasers = Instantiate(PlayerLasersPrefab, PlayerLasersSpawnPoint[j].position, PlayerBulletSpawnPoint[j].rotation);
                    _playerLasers.GetComponent<Rigidbody>().velocity = PlayerLasersSpawnPoint[j].right * PlayerLaserSpeed;
                }
            }
        }
    }

    IEnumerator PlayerShootingInputWithSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.X))
        {
            PlayerIsAudioSource.PlayOneShot(PlayerAudioShoot);

            yield return new WaitForSecondsRealtime(0.2f);

            for (int i = 0; i < PlayerBulletSpawnPoint.Length; i++)
            {
                var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[i].position, PlayerBulletSpawnPoint[i].rotation);
                _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[i].right * PlayerBulletSpeed;
            }

            if (PlayerLasersAreEnabled == true)
            {
                PlayerIsAudioSourceLaser.PlayOneShot(PlayerAudioShootLaser);

                yield return new WaitForSecondsRealtime(0.2f);

                for (int k = 0; k < PlayerBulletSpawnPoint.Length; k++)
                {
                    var _playerLasers = Instantiate(PlayerLasersPrefab, PlayerLasersSpawnPoint[k].position, PlayerBulletSpawnPoint[k].rotation);
                    _playerLasers.GetComponent<Rigidbody>().velocity = PlayerLasersSpawnPoint[k].right * PlayerLaserSpeed;
                }
            }
        }
    }
}