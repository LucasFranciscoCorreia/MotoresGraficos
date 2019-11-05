using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public delegate void OnEquipmentChanged();
    public OnEquipmentChanged onEquipmentChangedCallBack;

    public static EquipmentManager instance;


    public Equipment[] equipments;
    Inventory inventory;
    EquipmentUI equipmentUI;

    private void Awake()
    {
        instance = this;
        inventory = Inventory.instance;
        int n = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        equipments = new Equipment[n];
        equipmentUI = FindObjectOfType<EquipmentUI>();
    }

    #endregion
    

    public void Equip(Equipment equip)
    {
        int slot = (int) equip.slot;

        Equipment oldItem;
        if(equipments[slot] != null)
        {
            oldItem = equipments[slot];
            inventory.Add(oldItem);
        }
        equipments[slot] = equip;
        equipmentUI.UpdateUI();
        if(onEquipmentChangedCallBack != null)
            onEquipmentChangedCallBack.Invoke();
    }

    public void Unequip(Equipment equip)
    {
        int index = (int) equip.slot;
        if(equipments[index] != null)
        {
            var oldItem = equipments[index];
            inventory.Add(oldItem);
            equipments[index] = null;

            if (onEquipmentChangedCallBack != null)
                onEquipmentChangedCallBack.Invoke();
        }
    }
}
