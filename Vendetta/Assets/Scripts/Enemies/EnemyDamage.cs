using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float health = 50f;
    public GameObject[] consumable = new GameObject[1];
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            int random = Random.Range(0, 2);
            Instantiate(consumable[random], transform.position, Quaternion.identity);
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
