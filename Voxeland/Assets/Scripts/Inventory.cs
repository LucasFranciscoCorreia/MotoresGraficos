using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{

    #region Singleton

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);
        if(onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
