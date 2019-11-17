using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{

    WeaponScript weapon;
    EnemyScript itself;
    private void Start()
    {
        itself = GetComponentInParent<EnemyScript>();
        weapon = GetComponentInChildren<WeaponScript>();
    }
    void Attack()
    {
        weapon.DealDamage();
    }
    void Die()
    {
        Destroy(itself.gameObject);
    }
}
