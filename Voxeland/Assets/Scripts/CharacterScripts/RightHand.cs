using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    public GameObject weapon;
    public bool inUse;

    public void Equip(Equipment equip)
    {
        this.inUse = true;
        weapon = Instantiate(equip.model, this.transform);
    }

    public void Unequip()
    {
        Destroy(weapon);
        inUse = false;
    }
}
