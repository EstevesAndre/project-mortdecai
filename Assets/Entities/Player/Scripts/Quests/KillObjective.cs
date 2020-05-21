using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillObjective : QuestObjective
{
    public string enemyToKill;
    public int numberOfKills;

    public KillObjective(Transform _transform, int _index, string _description, string _enemyToKill, int _numberOfKills)
    {
        enemyToKill = _enemyToKill;
        numberOfKills = _numberOfKills;
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

    public override void Clear()
    {
        text.enabled = false;
        text.text = "";
    }
}
