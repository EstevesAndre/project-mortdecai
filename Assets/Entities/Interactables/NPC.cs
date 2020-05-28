using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Dictionary<string, int> itemsNeeded;
    // public QuestManager questManager; TODO
    public int questIndex;
    public bool hasInteractedSuccessfully;

    public void Interact(Player player)
    {
        if (!hasInteractedSuccessfully)
        {
            /*
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
            hasInteractedSuccessfully = true;
            // questManager.completeQuestObjective(questIndex); TODO
        }
            */
        }
    }
}
