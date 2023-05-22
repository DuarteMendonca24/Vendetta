using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float health = 50f;
    public GameObject[] consumable = new GameObject[1];
    private Animator animator;

    private EnemyRifle enemyRifle;
    private EnemyShotgun enemyShotgun;
    private EnemySniper enemySniper;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyRifle = GetComponent<EnemyRifle>();
        enemyShotgun = GetComponent<EnemyShotgun>();
        enemySniper = GetComponent<EnemySniper>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            animator.SetBool("IsDeath", true);
            enemyRifle.enabled = false;
            // enemyShotgun.enabled = false;
            // enemySniper.enabled = false;
           
            Invoke("DropConsumable", 6.0f);
            Invoke("Die",8.0f);
            Debug.Log("MORTE");
            
        }
    }

     void Die()
    {
        
        Destroy(gameObject);
    }

    void DropConsumable()
    {
        int random = Random.Range(0, 2);
        Instantiate(consumable[random], transform.position, Quaternion.identity);
    }

}
