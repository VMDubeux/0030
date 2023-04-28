using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public string GameSceneName;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    public void Play()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ReturnFromOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
