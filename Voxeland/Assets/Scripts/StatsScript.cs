using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth { get; private set; }
    public Stat damage;
    HPBar hp;

    private void Awake()
    {
        currentHealth = maxHealth;
        if (gameObject.CompareTag("Player"))
        {
            hp = FindObjectOfType<HPBar>();
            hp.UpdateValues(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }

        if (gameObject.CompareTag("Player"))
        {
            hp.UpdateValues(currentHealth, maxHealth);
        }

    }

    public virtual void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            GetComponent<EnemyScript>().isDead = true;
            GetComponent<EnemyScript>().Kill();
        }

    }
}
