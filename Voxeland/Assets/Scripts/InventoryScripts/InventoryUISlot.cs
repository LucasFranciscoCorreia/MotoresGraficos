using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{

    public Image icon;
    Item item;
    DescriptionManager description;
    public Vector3 offset;

    AnimationController animator;

    private void Start()
    {
        description = FindObjectOfType<DescriptionManager>();
        animator = FindObjectOfType<AnimationController>();
    }

    public void AddItem(Item item)
    {
        this.item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            
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
