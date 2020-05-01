using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    #region Fields

    private List<CollectibleType> items = new List<CollectibleType>();

    #endregion

    #region Getters and Setters

    public List<CollectibleType> GetItems()
    {
        return items;
    }

    #endregion

    #region Methods

    public void AddItem(CollectibleType itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(int indexToRemove)
    {
        // Create instance of an item prefab TODO
        // Attach the corrresponding Item component TODO
        // Place it near the player (?) TODO
        items.RemoveAt(indexToRemove);
    }

    public void UseItem(int indexToUse)
    {
        // ?? TODO
        items.RemoveAt(indexToUse);
    }

    #endregion
}
