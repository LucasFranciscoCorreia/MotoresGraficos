using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public string enemyTag;

    List<StatsScript> enemies;
    StatsScript stats;
    FloatingDamageController damagepopup;
    public BoxCollider col;

    private void Start()
    {
        stats = GetComponentInParent<StatsScript>();
        enemies = new List<StatsScript>();
        col = GetComponent<BoxCollider>();
        damagepopup = FindObjectOfType<FloatingDamageController>();
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
            damagepopup.CreateFloatingDamage($"{stats.damage.getValue()}", other.transform);
        }
    }

    public void DealDamage()
    {
        enemies = new List<StatsScript>();
        col.enabled = false;
    }

}
