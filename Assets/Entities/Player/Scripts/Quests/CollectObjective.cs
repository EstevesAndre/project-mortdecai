using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectObjective : QuestObjective
{
    public string itemToCollect;
    public int targetItemCount;
    public int itemCount;
    public CollectObjective(Transform _transform, int _index, string _description, int _targetItemCount, string _itemToCollect)
    {
        itemCount = 0;
        targetItemCount = _targetItemCount;
        itemToCollect = _itemToCollect;
        description = _description;
        isCompleted = false;

        text = _transform.GetChild(_index).GetComponent<TextMeshProUGUI>();
    }

    public override void UpdateUI(Player player)
    {
        itemCount = 0;

        foreach (InventorySlot item in player.GetInventory().container)
        {
            if (item.item.name == itemToCollect)
                itemCount = item.amount;
        }

        if (itemCount >= targetItemCount)
        {
            isCompleted = true;
        }

        PrintUI(player);
    }

    public override void PrintUI(Player player)
    {
        text.text = description + " (" + (itemCount > targetItemCount ? targetItemCount : itemCount) + "/" + targetItemCount + ")";
    }
}