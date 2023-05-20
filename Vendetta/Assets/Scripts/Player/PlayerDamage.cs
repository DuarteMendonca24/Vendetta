using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public int health = 50;
    public TextMeshProUGUI healthDisplay;
    public Slider healthBar;

    private void Start()
    {
        
    }

    //public function because we will need to call it from the gun script
    public void TakeDamage (int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }
    
    void Update()
    {
       // healthDisplay.text = "Health : " + health.ToString();
        healthBar.value = health;

    }
    void Die()
    {
        Destroy(gameObject);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("HealthKit"))
        {
            health += 20;
            if(health > 50)
            {
                health = 50;
            }
            // Destruir o objeto que foi colidido
            Destroy(hit.gameObject);

        }
    }
}
