using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjective : QuestObjective
{
    public string itemToCollect;
    public int itemCount;
    public int targetItemCount;
    public CollectObjective(string _description, int _targetItemCount, string _itemToCollect)
    {
        itemCount = 0;
        targetItemCount = _targetItemCount;
        itemToCollect = _itemToCollect;
        description = _description;
        isCompleted = false;
    }

    public override void Update(Player player)
    {
        foreach(InventorySlot item in player.GetInventory().container)
        {
            // TODO
        }
    }
}