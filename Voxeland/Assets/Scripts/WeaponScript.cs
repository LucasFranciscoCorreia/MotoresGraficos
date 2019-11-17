using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public string enemyTag;

    List<StatsScript> enemies;
    StatsScript stats;

    public BoxCollider col;

    private void Start()
    {
        stats = GetComponentInParent<StatsScript>();
        enemies = new List<StatsScript>();
        col = GetComponent<BoxCollider>(); 
    }

    public void StartCollider()
    {
        this.col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        StatsScript enemy = other.gameObject.GetComponent<StatsScript>();
        if (other.gameObject.CompareTag(enemyTag) && !enemies.Contains(enemy))
        {
            enemy.TakeDamage(stats.damage.getValue());
            enemies.Add(enemy);
        }
    }

    public void DealDamage()
    {
        enemies = new List<StatsScript>();
        col.enabled = false;
    }

}
