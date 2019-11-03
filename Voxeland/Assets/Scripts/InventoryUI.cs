using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;

    Inventory inventory;
    public InventoryUISlot[] slots;
    

    // Start is called before the first frame update
    void Awake()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventoryUISlot>();
        UpdateUI();
        FindObjectOfType<EquipmentUI>().UpdateUI();
    }

    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length;i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].ClearSlot();
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}
