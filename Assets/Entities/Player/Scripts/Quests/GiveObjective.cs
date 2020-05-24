using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiveObjective : QuestObjective
{
    public string allyToGive;
    public int countToGive;

    public GiveObjective(Transform _transform, int _index, string _description, string _allyToGive, int _countToGive)
    {
        allyToGive = _allyToGive;
        countToGive = _countToGive;
        description = _description;
        isCompleted = false;

        text = _transform.GetChild(_index).GetComponent<TextMeshProUGUI>();
    }

    public override void UpdateUI(Player player)
    {

    }

    public override void PrintUI(Player player)
    {

    }
}
