using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoof : MonoBehaviour
{
   

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float attackRange;
    public bool  playerInAttackRange;

    public float damage = 0.1f;
    public float range = 100f;

    

    public Transform attackPoint;
    //Graphics
    public GameObject muzzleFlash;

    private Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

       

       if (playerInAttackRange)
        {
          
            transform.LookAt(player);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsShooting", true);


            if (!alreadyAttacked )
            {

                AttackPlayer();
                animator.SetBool("IsShooting", false);


            }

        }
        else
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsShooting", false);
        }


    }

    private void AttackPlayer()
    {
        attackPoint.transform.rotation = Quaternion.LookRotation(transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(attackPoint.transform.position, attackPoint.transform.forward, out hitInfo, range))
        {
            //animator.SetTrigger("Fire");

            Debug.Log(range);
            //this only occurs if we hit something with our ray
            Debug.Log(hitInfo.transform.name);
            Debug.DrawRay(attackPoint.transform.position, attackPoint.transform.forward, Color.yellow, 5.0f);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {

                target.TakeDamage(damage);
            }

        }




        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, attackPoint.rotation, attackPoint);

        Destroy(flash, 0.10f);

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
