using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public bool isDead;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    Rigidbody body;
    float radius = 30;
    void Start()
    {
        isDead = false;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
        GetComponent<SphereCollider>().radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        var isWalking = false;
        var isAttacking = false;
        if (!isDead && target != null && !target.GetComponent<CharacterScript>().isDead)
        {
            isWalking = true;
            var distance = Vector3.Distance(transform.position, target.position);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CharacterScript>() != null)
        {
            target = other.gameObject.GetComponent<Transform>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterScript>() != null && Vector3.Distance(transform.position, other.gameObject.transform.position) > radius * transform.lossyScale.y)
        {
            target = null;
        }
    }
    public void Kill()
    {
        anim.SetBool("isDead", isDead);
    }
}
