using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjective : QuestObjective
{
    public string enemyToKill;
    public int numberOfKills;

    public KillObjective(string _description, string _enemyToKill, int _numberOfKills)
    {
        enemyToKill = _enemyToKill;
        numberOfKills = _numberOfKills;
        description = _description;
        isCompleted = false;
    }

    public override void Update(Player player)
    {

    }
}
