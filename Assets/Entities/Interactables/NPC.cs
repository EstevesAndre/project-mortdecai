using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dictionary<string, int> itemsNeeded;

    public void Interact(Player player)
    {
        int itemCount = 0;
        foreach (InventorySlot item in player.GetInventory().container)
        {
            int actualValue;
            if (itemsNeeded.TryGetValue(item.item.name, out actualValue) && actualValue == item.amount)
            {
                itemCount++;
            }
        }
        if (itemCount == itemsNeeded.Count)
        {
            // Player has all the item, remove them from the inventory and do stuff
        }
    }
}
