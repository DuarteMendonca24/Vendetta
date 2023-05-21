using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float health = 50f;
    public GameObject consumable;
    private Vector3 vector3;
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            //vector3 = transform.position;
            //vector3.y = 0.53f;
            Instantiate(consumable, transform.position, Quaternion.identity);
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
