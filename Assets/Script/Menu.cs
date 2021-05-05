using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Middle;
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void login()
    {
        SceneManager .LoadScene (1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Setting()
    {
        SceneManager.LoadScene(3);
    }
    public void About()
    {
        SceneManager .LoadScene (4);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    public void Return1()
    {
        SceneManager .LoadScene (3);
    }
    public void level1()
    {
        SceneManager.LoadScene(5);
    }
    public void level2()
    {
        SceneManager.LoadScene(6);
    }
    public void level3()
    {
        SceneManager.LoadScene(7);
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Middle.SetActive(false);
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Middle.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void NextGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}
