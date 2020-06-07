using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public int numItemsNeeded;
    public string collectionName;
    public QuestManager questManager;
    public int questIndex;
    public int objectiveIndex;
    private bool hasInteractedSuccessfully;
    public GameObject objectToDrop;

    public void Interact(Player player)
    {
        if (!hasInteractedSuccessfully)
        {
            int itemCount = 0;
            foreach (InventorySlot item in player.GetInventory().container)
            {
                if (item.item.name == collectionName)
                {
                    itemCount++;
                }
            }

            if (itemCount == numItemsNeeded)
            {
                hasInteractedSuccessfully = true;
                questManager.CompleteQuestObjective(questIndex, objectiveIndex);
                Debug.Log("COMPLETED");


                foreach (InventorySlot item in player.GetInventory().container)
                {
                    if (item.item.name == collectionName)
                    {
                        player.GetInventory().ConsumeItem(item);
                    }
                }

                

                if(objectToDrop != null)
                {
                    objectToDrop.SetActive(true);
                }
            }
        }
    }

    private IEnumerator ShowCollectables(float waitTime)
    {
        
        for(int i = 0; i < numItemsNeeded; i++)
        {

            yield return new WaitForSeconds(waitTime);
        }
    }
}
