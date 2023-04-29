using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    //public function because we will need to call it from the gun script
    public void TakeDamage (float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
