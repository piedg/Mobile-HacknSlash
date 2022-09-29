using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public Health Player;
    public int KillCount;
    public bool IsPause;

    const string GameScene = "Game";
    const string MainMenuScene = "MainMenu";

    private void Start()
    {
    }

    private void Update()
    {
        if (IsPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }
}
