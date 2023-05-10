using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsManager : MonoBehaviour
{
    [SerializeField] private string _writeTheCurrentGameSceneName;
    [SerializeField] private string _writeMenu;
    [SerializeField] private string _writeTheNextGameSceneName;
    
    public Transform PauseMenu;

    public void RestartGame()
    {
        SceneManager.LoadScene(_writeTheCurrentGameSceneName);
    }

    public void NextGameScene()
    {
        SceneManager.LoadScene(_writeTheNextGameSceneName);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_writeMenu);
    }

    public void ResumeGame() 
    {
        PauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
