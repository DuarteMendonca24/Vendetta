using UnityEngine;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{

    public float health = 50f;
    public GameObject[] consumable = new GameObject[1];
    public GameObject key;
    private Animator animator;

    private EnemyRifle enemyRifle;
    private EnemyShotgun enemyShotgun;
    private EnemySniper enemySniper;
    private Boss boss;
    private KillCount killCount;

    private bool isDead = false;

    Collider capsuleCollider;
    public NavMeshAgent agent;

    
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyRifle = GetComponent<EnemyRifle>();
        enemyShotgun = GetComponent<EnemyShotgun>();
        enemySniper = GetComponent<EnemySniper>();
        boss = GetComponent<Boss>();
        capsuleCollider = GetComponent<Collider>();
        killCount = GameObject.Find("Enemies").GetComponent<KillCount>();
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

                else if(boss != null)
                {
                    Time.timeScale = 0f;
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
        if (killCount.enemyCount >= 2)
        {
            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5)
            {
                int randomconsumable = Random.Range(0, 5);
                Instantiate(consumable[randomconsumable], transform.position, Quaternion.identity);
            }
        }
        else if(killCount.enemyCount < 2)
        {
            //Debug.Log("Estou aqui");
            Instantiate(key, transform.position, Quaternion.identity);
        }
    }

}
