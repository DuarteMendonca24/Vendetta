using TMPro;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float health = 50f;
    public TextMeshProUGUI healthDisplay;
   

    //public function because we will need to call it from the gun script
    public void TakeDamage (float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }
    
    void Update()
    {
        healthDisplay.text = "Health : " + health.ToString();
        

    }
    void Die()
    {
        Destroy(gameObject);
    }
}
