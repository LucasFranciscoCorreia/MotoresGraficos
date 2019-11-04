using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUISlot : MonoBehaviour
{
    public Image icon;
    Equipment item;
    DescriptionManager description;
    public Vector3 offset;
    private void Start()
    {
        description = FindObjectOfType<DescriptionManager>();
    }

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

    public void OnHover()
    {
        if (item != null)
        {
            description.offset = this.offset;
            description.AddItem(item);
        }
    }

    public void OffHover()
    {
        description.RemoveItem();
    }
}
