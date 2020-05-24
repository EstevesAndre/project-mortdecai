using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest
{
    private Transform transform;
    public string title;
    public int zone;
    public List<QuestObjective> objectives;
    public bool isCompleted;
    private TextMeshProUGUI titleMesh;

    public Quest(Transform _transform, int _zone, string _title, List<QuestObjective> _objectives)
    {
        transform = _transform;
        title = _title;
        zone = _zone;
        objectives = _objectives;

        isCompleted = false;
        titleMesh = _transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUI(Player player)
    {
        if (isCompleted)
            return;

        titleMesh.text = title;

        bool check = true;

        foreach (QuestObjective obj in objectives)
        {
            if (!obj.isCompleted)
            {
                check = false;
                obj.UpdateUI(player);
            }
            else
            {
                obj.PrintUI(player);
            }
        }

        if (check)
        {
            isCompleted = true;
        }
    }
}
