using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunSystem2 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    public Transform attackPoint;
    //Graphics
    public GameObject muzzleFlash;

    public float ammo = 20f;

    public TextMeshProUGUI ammoDisplay;


 

    private void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
       
        

    }
    // Update is called once per frame
    void Update()
    {
       
        ammoDisplay.text = "Ammo : " + ammo.ToString();
        //Fire1 is a default button set up by Unity , left mouse button
        if (Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused == false && ammo > 0) {

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
        //variable used to store some information about what we shot with our ray
        RaycastHit hitInfo;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward , out hitInfo , range)){

            //this only occurs if we hit something with our ray
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

        }

        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, attackPoint.rotation, attackPoint);

        Destroy(flash,0.020f);
    }

}
