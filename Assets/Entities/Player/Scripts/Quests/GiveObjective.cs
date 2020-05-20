using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveObjective : QuestObjective
{
    public string allyToGive;
    public int countToGive;

    public GiveObjective(string _description, string _allyToGive, int _countToGive)
    {
        allyToGive = _allyToGive;
        countToGive = _countToGive;
        description = _description;
        isCompleted = false;
    }
    
    public override void Update(Player player)
    {

    }
}
