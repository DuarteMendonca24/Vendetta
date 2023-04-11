using UnityEngine;

public class GunSystem2 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    private void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;

    }
    // Update is called once per frame
    void Update()
    {
        

        //Fire1 is a default button set up by Unity , left mouse button
        if (Input.GetButtonDown("Fire1")){

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
        }

    }
}
