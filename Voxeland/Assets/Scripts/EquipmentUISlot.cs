using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUISlot : MonoBehaviour
{
    public Image icon;
    Equipment item;


    public void EquipItem(Equipment item)
    {
        this.item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void Unequip()
    {
        if(item != null)
        {
            item.Unequip();
            this.icon.sprite = null;
            this.icon.enabled = false;
        }
    }
}
