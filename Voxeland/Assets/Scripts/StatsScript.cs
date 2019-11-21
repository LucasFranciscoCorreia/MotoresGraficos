using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth { get; private set; }
    public Stat damage;
    HPBar hp;
    EnemyHPBar enemyhp;

    private void Awake()
    {
        currentHealth = maxHealth;
        if (gameObject.CompareTag("Player"))
        {
            hp = FindObjectOfType<HPBar>();
            hp.UpdateValues(currentHealth, maxHealth);
        }else
        {
            enemyhp = GetComponentInChildren<EnemyHPBar>();
            enemyhp.UpdateValues(currentHealth, maxHealth);            
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
        else
        {
            enemyhp.UpdateValues(currentHealth, maxHealth);
            GetComponent<EnemyScript>().TrigDamage();
        }

    }

    public virtual void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            GetComponent<EnemyScript>().isDead = true;
            GetComponent<EnemyScript>().Kill();
        }else if (gameObject.CompareTag("Player"))
        {
            GetComponent<CharacterScript>().isDead = true;
            GetComponent<CharacterScript>().Die();
        }

    }
}
