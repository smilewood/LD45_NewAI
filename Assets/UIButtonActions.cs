using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonActions : MonoBehaviour
{
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
