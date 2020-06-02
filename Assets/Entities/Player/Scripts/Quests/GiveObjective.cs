using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiveObjective : QuestObjective
{
    public GiveObjective(Transform _transform, int _index, string _description)
    {
        description = _description;
        isCompleted = false;

        text = _transform.GetChild(_index).GetComponent<TextMeshProUGUI>();
    }

    public override void UpdateUI(Player player)
    {
        PrintUI(player);
    }

    public override void PrintUI(Player player)
    {
        text.text = description + "(" + (isCompleted ? "1":"0") + "/1)";
    }

    public override void Complete()
    {
        isCompleted = true;
    }
}
