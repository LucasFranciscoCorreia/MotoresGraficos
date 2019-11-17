using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot slot;
    public int armorModifier;
    public int damageModifier;

    public Vector3 pos;
    public Vector3 rotation;
    public Vector3 scale;

    public GameObject model;

    AnimationController animator;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);

        if (slot == EquipmentSlot.rightHand)
            FindObjectOfType<RightHand>().Equip(this);

        RemoveFromInventory();
    }

    public void Unequip()
    {
        if (animator == null)
            animator = FindObjectOfType<AnimationController>();

        if (slot == EquipmentSlot.rightHand)
            FindObjectOfType<RightHand>().Unequip();

        
        EquipmentManager.instance.Unequip(this);
    }
}

public enum EquipmentSlot
{
    Head, Chest, Legs, leftHand, rightHand
}