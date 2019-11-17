using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    public GameObject weapon;
    public bool inUse;
    AnimationController animator;

    private void Start()
    {
        animator = FindObjectOfType<AnimationController>();
    }

    public void Equip(Equipment equip)
    {
        this.inUse = true;
        weapon = Instantiate(equip.model, transform);
        animator.SetWeapon(weapon.GetComponent<WeaponScript>());
    }

    public void Unequip()
    {
        Destroy(weapon);
        inUse = false;
    }
}
