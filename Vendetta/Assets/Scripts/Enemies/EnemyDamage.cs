using UnityEngine;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{

    public float health = 50f;
    public GameObject[] consumable = new GameObject[1];
    private Animator animator;

    private EnemyRifle enemyRifle;
    private EnemyShotgun enemyShotgun;
    private EnemySniper enemySniper;

    private bool isDead = false;

    Collider capsuleCollider;
    public NavMeshAgent agent;

    private int consumableRange = 6;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyRifle = GetComponent<EnemyRifle>();
        enemyShotgun = GetComponent<EnemyShotgun>();
        enemySniper = GetComponent<EnemySniper>();
        capsuleCollider = GetComponent<Collider>();
    }
    public void TakeDamage(float amount)
    {
        if (isDead == false)
        {
            health -= amount;
            if (health <= 0)
            {
                animator.SetBool("IsDeath", true);
                if (agent != null)
                {
                    agent.SetDestination(transform.position);
                }
                
                isDead = true;
                if (enemyRifle != null)
                {
                    capsuleCollider.enabled = false;
                    enemyRifle.enabled = false;
                    
                }
                else if (enemyShotgun != null)
                {
                    enemyShotgun.enabled = false;
                }
                else if (enemySniper != null)
                {
                    enemySniper.enabled = false;
                }

                
                if(agent != null)
                {
                    Invoke("DropConsumable", 3.0f);
                }
                
                    
                
                Invoke("Die", 7.0f);
                capsuleCollider.enabled = false;

            }
        }
        
    }

     void Die()
    {
        
        Destroy(gameObject);
    }

    void DropConsumable()
    {
        Debug.Log("DROPOU");
        int random = Random.Range(0, 10);
        
        if(random == 0 || random==1 || random == 2 || random == 3)
        {
            int randomconsumable = Random.Range(0, consumableRange);
            Instantiate(consumable[randomconsumable], transform.position, Quaternion.identity);
            Debug.Log(randomconsumable);
            if (randomconsumable == 5)
            {
                consumableRange = 5;
            }
            
        }
       
    }

}
