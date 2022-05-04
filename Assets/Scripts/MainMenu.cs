using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        Debug.Log("start game");
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
    
}
