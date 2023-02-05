using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPersistent<GameManager>
{
    public bool GamePaused { get; private set; }
    public bool LevelCompleted { get; private set; }
    public bool IsGameOver { get; private set; }

    #region Load Scenes
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GamePaused = false;
        IsGameOver = false;
        LevelCompleted = false;

        //switch (scene.name)
        //{
        //    case "Menu":
        //        // If it's the main menu
        //        // Do some stuff

        //        break;
        //    case "Main":
        //        // If it's the main scene
        //        // Do other stuff here
        //        // Initialize all the stuff that we need like sounds and shit

        //        break;
        //    default:
        //        // If it's neither of those, do something else who knows

        //        break;
        //}
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void RestartLevel()
    {
        print("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    #region Game Flow

    public bool IsGamePaused()
    {
        return (SceneManager.GetActiveScene().name == "Main Menu") || (GamePaused);
    }

    public void ToggleGamePause()
    {
        if (LevelCompleted || IsGameOver) return;

        GamePaused = !GamePaused;

        if (GamePaused)
        {
            // Pause
        }
        else
        {
            // Unpause
        }
    }

    public void GameOver()
    {
        if (IsGameOver || LevelCompleted) return;

        IsGameOver = true;
        StartCoroutine(UIManager.Instance.ShowGameOverPanel());
    }
    #endregion
}
