using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.XR;


public class Target : MonoBehaviour
{
    public float health = 50.0f;
    public TextMeshProUGUI healthDisplay;

    private void Start()
    {
        
    }
    void Update()
    {
        healthDisplay.text = "Health : " + health.ToString();
        
    }

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
