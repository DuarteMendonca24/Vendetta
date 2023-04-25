using UnityEngine;

public class GunSystem2 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    public Transform attackPoint;
    //Graphics
    public GameObject muzzleFlash;


    
  
    

    private void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
       
        

    }
    // Update is called once per frame
    void Update()
    {
       

        //Fire1 is a default button set up by Unity , left mouse button
        if (Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused == false) {

            Shoot();

        }
    }

    public void Shoot()
    {   
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

        float offset = 0.02f; // decrease this value to move the muzzle flash closer to the attackPoint

        GameObject flash = Instantiate(muzzleFlash, attackPoint.position + attackPoint.forward * offset, attackPoint.rotation);
      
        Destroy(flash,0.020f);
    }

}
