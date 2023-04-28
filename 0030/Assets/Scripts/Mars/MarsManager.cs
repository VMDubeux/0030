using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsManager : MonoBehaviour
{
    [SerializeField] private string marsGameScene;
    [SerializeField] private string mainMenuGameScene;
    [SerializeField] private string _nextGameScene;
    [SerializeField] private GameObject CanvasLose;

    public void RestartGame()
    {
        SceneManager.LoadScene(marsGameScene);
    }

    public void NextGameScene()
    {
        SceneManager.LoadScene(_nextGameScene);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuGameScene);
    }

    public void LoseGame()
    { 
        MarsManager.Instantiate(CanvasLose);
    }

    public void ExitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
