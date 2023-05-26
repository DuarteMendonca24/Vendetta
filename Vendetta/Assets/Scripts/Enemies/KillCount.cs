using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillCount : MonoBehaviour
{
   // public GameObject enemy;
    public int killCount = 0;
    public int enemyCount = 0;
    public int previousCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform enemy in transform)
        {
            enemyCount++;
        }
        previousCount = enemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = 0;
        foreach (Transform enemy in transform)
        {
            //Debug.Log("Ola" + enemy);
            enemyCount++;
            
        }
        //Debug.Log(enemyCount);
        if (enemyCount < previousCount)
        {
            killCount += previousCount - enemyCount;   
        }

        
        previousCount = enemyCount;
        
        
    }

    
   
}
