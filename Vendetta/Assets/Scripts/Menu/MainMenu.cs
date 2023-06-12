using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("ThemeSong");
        FindObjectOfType<AudioManager>().StopSound("GameSong");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Introduction");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
