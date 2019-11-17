using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public float lookRadius;
    public bool isDead;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    Rigidbody body;
    void Start()
    {
        isDead = false;
        anim = GetComponentInChildren<Animator>();
        target = FindObjectOfType<CharacterScript>().transform;
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            var isWalking = false;
            var isAttacking = false;
            var distance = Vector3.Distance(transform.position, target.position);
            if (distance <= lookRadius)
            {
                isWalking = true;
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    isWalking = false;
                    isAttacking = true;
                    Vector3 direction = (target.position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
                }
            }

            anim.SetBool("isWalking", isWalking);
            anim.SetBool("isAttacking", isAttacking);
            body.velocity = Vector3.zero;
        }
    }

    public void Kill()
    {
        anim.SetBool("isDead", isDead);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
