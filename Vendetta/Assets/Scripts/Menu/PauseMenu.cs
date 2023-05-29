using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GunSystem2 PistolGunSystem;
    private GunSystem2 M4GunSystem;
    private GunSystem2 ShotGunSystem;
    public LoadScene loadScene;
    private PlayerMovement playerMovement;
    private InputManager inputManager;
    private WeponSwitching weponSwitching;

    public GameObject pauseMenuUI;

    private void Start()
    {
        weponSwitching = GameObject.FindGameObjectWithTag("WeponHolder").GetComponent<WeponSwitching>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        PistolGunSystem = GameObject.FindGameObjectWithTag("Pistol").GetComponent<GunSystem2>();
        PistolGunSystem = GameObject.FindGameObjectWithTag("Rifle").GetComponent<GunSystem2>();
        PistolGunSystem = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<GunSystem2>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        inputManager.enabled = true;
        weponSwitching.enabled = true;
        PistolGunSystem.enabled = true;
        M4GunSystem.enabled = true;
        ShotGunSystem.enabled = true;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        inputManager.enabled = false;
        weponSwitching.enabled = false;
        PistolGunSystem.enabled = false;
        M4GunSystem.enabled = false;
        ShotGunSystem.enabled = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
