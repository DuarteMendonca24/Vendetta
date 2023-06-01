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
    private PlayerDamage playerDamage;
    private InputManager inputManager;
    private WeponSwitching weponSwitching;

    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;



    private void Start()
    {
        weponSwitching = GameObject.FindGameObjectWithTag("WeponHolder").GetComponent<WeponSwitching>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>();
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
       //comentei porque me estava a dar erro 
       //como a rifle e a shotgun começam disabed , não dá para aceder aos seus componentes
       //PistolGunSystem = GameObject.FindGameObjectWithTag("Pistol").GetComponent<GunSystem2>();
       //M4GunSystem = GameObject.FindGameObjectWithTag("Rifle").GetComponent<GunSystem2>();
       //ShotGunSystem = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<GunSystem2>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerDamage.health > 0)
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Pause();
            }
        }
        else if(playerDamage.health < 0)
        {
            
            gameOverMenuUI.SetActive(true);
            //Pause();
           
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
        //PistolGunSystem.enabled = true;
        //M4GunSystem.enabled = true;
        //ShotGunSystem.enabled = true;
    }

    private void Pause()
    {
       
        Time.timeScale = 0f;
        
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        inputManager.enabled = false;
        weponSwitching.enabled = false;
        //PistolGunSystem.enabled = false;
        //M4GunSystem.enabled = false;
        //ShotGunSystem.enabled = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    
}
