using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest
{
    public string title;
    public int zone;
    public List<QuestObjective> objectives;
    public bool isCompleted;
    private TextMeshProUGUI titleMesh;

    public Quest(Transform transform, int _zone, string _title, List<QuestObjective> _objectives)
    {
        title = _title;
        zone = _zone;
        objectives = _objectives;

        isCompleted = false;
        titleMesh = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUI(Player player)
    {
        if (isCompleted) {
            foreach(QuestObjective obj in objectives) {
                obj.PrintUI(player);
            }
               
            return;
        }
        
        bool check = true;
        titleMesh.text = title;

        foreach(QuestObjective obj in objectives)
        {
            if (!obj.isCompleted)
            {
                check = false;
                obj.UpdateUI(player);
            }
        }

        if(check) {
            isCompleted = true;
            titleMesh.enabled = false;
            titleMesh.text = "";
            
            foreach(QuestObjective obj in objectives)
            {
                obj.Clear();
            }
        }
    }
}
