using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string title;
    public List<QuestObjective> objectives;
    public bool isCompleted;

    public Quest(string _title, List<QuestObjective> _objectives)
    {
        title = _title;
        objectives = _objectives;

        isCompleted = false;
    }

    public void Update(Player player)
    {
        if (isCompleted) return;
        
        bool check = true;
        foreach(QuestObjective obj in objectives)
        {
            if (!obj.isCompleted)
            {
                check = false;
                obj.Update(player);
            }
        }

        if(check) isCompleted = true;
    }
}
