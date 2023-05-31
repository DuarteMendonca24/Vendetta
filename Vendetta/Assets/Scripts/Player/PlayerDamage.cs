using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayerDamage : MonoBehaviour
{
    public int health = 50;
    public TextMeshProUGUI healthDisplay;
    public Slider healthBar;
    private DoorOpening door;

    [Header("Gun Systems")]
    public GunSystem2 PistolGunSystem;
    public GunSystem2 M4GunSystem;
    public GunSystem2 ShotGunSystem;
    public LoadScene loadScene;
    private PlayerMovement playerMovement;
    private InputManager inputManager;
    private WeponSwitching weponSwitching;

    public GameObject gameOverUI;

    public Camera playerCamera;
    public Camera doorCamera;


    private void Awake()
    {
        //PistolGunSystem = GameObject.FindGameObjectWithTag("Pistol").GetComponent<GunSystem2>();
        //PistolGunSystem = GameObject.FindGameObjectWithTag("Rifle").GetComponent<GunSystem2>();
        //PistolGunSystem = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<GunSystem2>();
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorOpening>();
        loadScene = GameObject.FindGameObjectWithTag("Letter").GetComponent<LoadScene>();
        weponSwitching = GameObject.FindGameObjectWithTag("WeponHolder").GetComponent<WeponSwitching>();
        playerMovement = GetComponent<PlayerMovement>();
        inputManager = GetComponent<InputManager>();
    }

    //public function because we will need to call it from the gun script
    public void TakeDamage (int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }
    
    void Update()
    {
       // healthDisplay.text = "Health : " + health.ToString();
        healthBar.value = health;

    }
    void Die()
    {
        //Scene scene = SceneManager.GetActiveScene();
        //GameOverMenu overMenu = FindAnyObjectByType<GameOverMenu>();
        //overMenu.RestartScene(scene.name);
        //gameOverUI.SetActive(true);
        // Destroy(gameObject);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("SmallHealthKit"))
        {
            health += 20;
            if(health > 50)
            {
                health = 50;
            }
            // Destruir o objeto que foi colidido
            Destroy(hit.gameObject);

        }

        if (hit.collider.CompareTag("BigHealthKit"))
        {
            health = 50;
            Destroy(hit.gameObject);
        }

        if (hit.collider.CompareTag("PistolAmmo"))
        {
            //Debug.Log("Pistol ammo");
            PistolGunSystem.maxcolder += 12;
            if (PistolGunSystem.maxcolder > 24) PistolGunSystem.maxcolder = 24;
            // Destruir o objeto que foi colidido
            Destroy(hit.gameObject);
        }

        if (hit.collider.CompareTag("RifleAmmo"))
        {
            M4GunSystem.maxcolder += 20;
            if (M4GunSystem.maxcolder > 40) M4GunSystem.maxcolder = 40;
            // Destruir o objeto que foi colidido
            Destroy(hit.gameObject);
        }

        if (hit.collider.CompareTag("ShotgunAmmo"))
        {
            ShotGunSystem.maxcolder += 8;
            if (ShotGunSystem.maxcolder > 12) ShotGunSystem.maxcolder = 12;
            // Destruir o objeto que foi colidido
            Destroy(hit.gameObject);
        }

        if (hit.collider.CompareTag("Key"))
        {
            door.enabled = true;
            playerCamera.enabled = false;
            doorCamera.enabled = true;
            //GameObject.Find("Video").GetComponent<VideoPlayer>().Play();
            Destroy(hit.gameObject);
        }

        if (hit.collider.CompareTag("Letter"))
        {
            //Destroy(hit.gameObject);
            playerMovement.enabled = false;
            inputManager.enabled = false;
            weponSwitching.enabled = false;
            PistolGunSystem.enabled = false;
            M4GunSystem.enabled = false;
            ShotGunSystem.enabled = false;
            loadScene.LoadLevel("Level2");
        }
    }
}
