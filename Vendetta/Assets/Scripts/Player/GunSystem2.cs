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

    public float ammo = 20f;
    public TextMeshProUGUI ammoDisplay;

    private float nextShotTime = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        ammoDisplay.text = "Ammo : " + ammo.ToString();

        if (Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused == false && ammo > 0 && Time.time >= nextShotTime)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 20f;
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
        Destroy(flash, 0.020f);

        // Set the next shot time based on the fire rate
        nextShotTime = Time.time + fireRate;
    }
}
