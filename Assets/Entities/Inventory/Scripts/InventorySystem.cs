using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    #region Fields

    private int size = 10;
    private List<InventoryItem> items = new List<InventoryItem>();

    #endregion

    #region Delegates

    public delegate void OnChange();
    public OnChange OnChangeCallback;

    #endregion

    #region Getters and Setters

    public List<InventoryItem> GetItems()
    {
        return items;
    }

    public int GetCount()
    {
        return items.Count;
    }

    #endregion

    #region Methods

    public void AddItem(InventoryItem itemToAdd)
    {
        Debug.Log("Adding item to inventory: " + itemToAdd.type);
        items.Add(itemToAdd);
        if (OnChangeCallback != null)
        {
            OnChangeCallback.Invoke();
        }
    }

    public void RemoveItem(int indexToRemove)
    {
        // Create instance of an item prefab TODO
        // Attach the corrresponding Item component TODO
        // Place it near the player (?) TODO
        items.RemoveAt(indexToRemove);
        OnChangeCallback.Invoke();
    }

    #endregion
}
