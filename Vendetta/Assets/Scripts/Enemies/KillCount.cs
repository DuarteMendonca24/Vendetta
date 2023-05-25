using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public GameObject enemy;
    public int killCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        foreach (Transform enemy in enemy.transform)
        {
            if (enemy.IsDestroyed())
            {
                killCount++;
            }
        }
    }
   
}
