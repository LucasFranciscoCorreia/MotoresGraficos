using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{

    public GameObject holder;
    public Vector3 offset;
    
    public Text name;
    public Text description;
    public Text status;

    Item item;

    void Start()
    {
        holder.SetActive(false);    
    }

    void Update()
    {
        if (!holder.activeSelf)
            return;
        if(holder.transform.position != Input.mousePosition + offset)
            holder.transform.position = Input.mousePosition + offset;
    }

    public void AddItem(Item item)
    {
        this.item = item;
        this.name.text = item.name;
        this.description.text = item.Description;
        if(item is Equipment)
        {
            var aux = (Equipment)item;
            if (aux.slot == EquipmentSlot.leftHand || aux.slot == EquipmentSlot.rightHand)
                status.text = "Attack: " + aux.damageModifier;
            else
                status.text = "Defense: " + aux.armorModifier;
        }
        holder.SetActive(true);
    }

    public void RemoveItem()
    {
        this.item = null;
        holder.SetActive(false);
    }



}
