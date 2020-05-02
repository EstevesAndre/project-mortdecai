using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    #region Fields

    public Player owner;
    private InventorySlot[] slots;

    public Transform itemsParent;

    #endregion

    #region Methods

    public void Start()
    {
        owner.GetInventorySystem().OnChangeCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateUI()
    {
        Debug.Log("Update UI called");
        List<InventoryItem> inventory = owner.GetInventorySystem().GetItems();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < owner.GetInventorySystem().GetCount())
            {
                slots[i].AddItem(inventory[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }

    #endregion

}
