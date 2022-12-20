using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Levels()
    {
        levelMenu.SetActive(true);
    }

    public void BackMenu()
    {
        levelMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
