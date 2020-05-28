using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class QuestObjective
{
    public string description;
    public bool isCompleted;
    public TextMeshProUGUI text;
    public abstract void UpdateUI(Player player);
    public abstract void PrintUI(Player player);
    public abstract void Complete();
}
