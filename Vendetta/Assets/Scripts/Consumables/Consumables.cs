using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Consumables : MonoBehaviour
{
    public float floatSpeed = 1.0f;  // Speed of the floating movement
    public float floatHeight = 1.0f; // Height of the floating movement

    private Vector3 startPosition;

    private void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new position using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }






}
