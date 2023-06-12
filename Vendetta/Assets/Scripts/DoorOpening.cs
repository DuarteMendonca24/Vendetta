using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DoorOpening : MonoBehaviour
{
    public Transform door;
    // Angular speed in degrees per sec.
    float speed = 15.0f;
    public Camera playerCamera;
    public Camera doorCamera;



    // Start is called before the first frame update
    void Start()
    {
        door = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // The step size is equal to speed times frame time.
        var step = speed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0f, 90f, 0f);

        // Rotate our transform a step closer to the target's.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        Debug.Log(transform.rotation.y);

        // Check if the rotation is done
        if (Quaternion.Angle(transform.rotation, targetRotation) <= 0.01f)
        {   
            doorCamera.enabled = false;
            playerCamera.enabled = true;
        }
    }
}
