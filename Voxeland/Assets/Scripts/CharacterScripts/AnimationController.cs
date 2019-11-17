using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    CharacterScript character;
    WeaponScript weapon;
    void Start()
    {
        character = GetComponentInParent<CharacterScript>();
        weapon =    GetComponentInChildren<WeaponScript>();
    }

    public void Jumping()
    {
        
    }

    public void OnGround()
    {
        character.isJumping = false;
    }

    public void FinishAttack()
    {
        character.isAttacking = false;
        if (weapon != null)
        {
            Debug.Log("Not null weapon");
            weapon.DealDamage();
        }
    }

    public void EnableWeapon()
    {
        if(weapon != null)
            weapon.StartCollider();
    }

    public void SetWeapon(WeaponScript weapon)
    {
        this.weapon = weapon;
    }
}
