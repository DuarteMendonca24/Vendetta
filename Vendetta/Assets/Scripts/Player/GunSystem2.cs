using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunSystem2 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 0.2f;

    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject muzzleFlash;

    public int ammo = 20;
    public int maxcolder = 20;
    public int savemax;
    public TextMeshProUGUI ammoDisplay;

    private float nextShotTime = 0.0f;

  

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        savemax = maxcolder;
      
    }

    private void Update()
    {
        ammoDisplay.text =  ammo.ToString() + "/" + maxcolder.ToString();

        if (Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused == false && ammo > 0 && Time.time >= nextShotTime)
        {
            Shoot();
            if (gameObject.CompareTag("Pistol"))
            {
                FindObjectOfType<AudioManager>().PlaySound("PistolShot");
            }
            else if (gameObject.CompareTag("Shotgun"))
            {
                FindObjectOfType<AudioManager>().PlaySound("ShotgunShot");
            }
            else if (gameObject.CompareTag("Rifle"))
            {
                FindObjectOfType<AudioManager>().PlaySound("RifleShot");
            }


        }

        
        if (Input.GetKeyDown(KeyCode.R))
        {
              
                for(; ammo<savemax && maxcolder>0; ammo++ )
                {   
                   
                    maxcolder--;
                }
              
        }
    }

    public void Shoot()
    {
        ammo--;

        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            EnemyDamage target = hitInfo.transform.GetComponent<EnemyDamage>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, attackPoint.rotation, attackPoint);
        Destroy(flash, 0.15f);

        // Set the next shot time based on the fire rate
        nextShotTime = Time.time + fireRate;
    }
}
