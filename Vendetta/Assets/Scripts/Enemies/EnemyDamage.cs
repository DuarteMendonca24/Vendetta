using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float health = 50f;
    public GameObject[] consumable = new GameObject[1];
    private Animator animator;

    private EnemyRifle enemyRifle;
    private EnemyShotgun enemyShotgun;
    private EnemySniper enemySniper;

    private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyRifle = GetComponent<EnemyRifle>();
        enemyShotgun = GetComponent<EnemyShotgun>();
        enemySniper = GetComponent<EnemySniper>();
    }
    public void TakeDamage(float amount)
    {
        if (isDead == false)
        {
            health -= amount;
            if (health <= 0)
            {
                isDead = true;
                animator.SetBool("IsDeath", true);
                if (enemyRifle != null)
                {
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

                Invoke("DropConsumable", 3.0f);
                Invoke("Die", 7.0f);
                Debug.Log("MORTE");


            }
        }
        
    }

     void Die()
    {
        
        Destroy(gameObject);
    }

    void DropConsumable()
    {   
        int random = Random.Range(0, 10);
        if(random == 0 || random==1 || random == 2 || random == 3)
        {
            int randomconsumable = Random.Range(0, 2);
            Instantiate(consumable[randomconsumable], transform.position, Quaternion.identity);
        }
       
    }

}
