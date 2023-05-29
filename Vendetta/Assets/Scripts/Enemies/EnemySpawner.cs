using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   
    public GameObject enemy;
    private bool playerInRange;
    public LayerMask whatIsPlayer;
    public int range = 10;
    public int enemyCounter = 0;
    public GameObject enemypack;
    [SerializeField]
    private int reapeatRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 5, reapeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position,range, whatIsPlayer);
    }

    private void spawnEnemy()
    {   
        if(!playerInRange && enemyCounter != 10)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, enemypack.transform);
            //enemy.transform.parent = enemypack.transform;
            enemyCounter++;
        }
        
       
    }

    void OnDrawGizmosSelected()
    {
        // Desenha a esfera de arame na cor vermelha
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
