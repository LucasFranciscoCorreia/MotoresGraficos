using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform equipmentsParent;

    EquipmentManager equipment;
    public EquipmentUISlot[] equipments;

    public void Start()
    {
        equipment = EquipmentManager.instance;
        equipment.onEquipmentChangedCallBack += UpdateUI;
        equipments = equipmentsParent.GetComponentsInChildren<EquipmentUISlot>();
        UpdateUI();
        this.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        for (int i = 0; i < equipments.Length; i++)
        {
            if (equipment.equipments[i] != null)
            {
                equipments[i].EquipItem(equipment.equipments[i]);
            }
            else
            {
                equipments[i].Unequip();
            }
        }
    }
}
