using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvasMenu;
    public GameObject Player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvasMenu.activeSelf)
            {
                PauseCanvasMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PauseCanvasMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Player.GetComponent<PlayerHealth>()._playerHealth <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
