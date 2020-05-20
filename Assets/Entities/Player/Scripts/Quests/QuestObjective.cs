using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestObjective
{   
    public string description;
    public bool isCompleted;

    public abstract void Update(Player player);
}
