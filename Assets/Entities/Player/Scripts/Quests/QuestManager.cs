using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public Player player;
    private List<Quest> quests;
    private bool finished;
    public int zone;

    // Start is called before the first frame update
    void Start()
    {
        quests = new List<Quest>();

        quests.Add(new Quest(
            transform,
            0,
            "Gather Objects",
            new List<QuestObjective>() {
                new CollectObjective(transform, 1, "Find mushrooms to open the portal", 3, "mushroomPortal"),
                new CollectObjective(transform, 2, "Collect all Candy House items", 2, "candyHouseItem"),
                new GiveObjective(transform, 3, "Interact with the Candy House")
            }
        ));
        quests.Add(new Quest(
            transform,
            1,
            "Gather Objects",
            new List<QuestObjective>() {
                new CollectObjective(transform, 1, "Find mushrooms", 1, "strawberry"),
                new CollectObjective(transform, 2, "Find invisibility feather", 1, "invisibilityFeather")
            }
        ));
        Debug.Log(quests.Count);

        zone = 0;
        finished = false;
        clearUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            return;
        }

        quests[zone].UpdateUI(player);
    }

    public void setZone(int _zone)
    {
        zone = _zone;
        clearUI();
    }

    private void clearUI()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    public void verifyAllQuests()
    {
        bool finished_ = true;
        // Print All quests are completed
        foreach (Quest quest in quests)
        {
            if (!quest.isCompleted)
                finished_ = false;
        }

        finished = finished_;

        if (finished)
        {
            int count = 1;
            foreach (Transform child in transform)
            {

                if (count == transform.childCount)
                {
                    child.GetComponent<TextMeshProUGUI>().enabled = true;
                    child.GetComponent<TextMeshProUGUI>().text = "All quests complete!";
                }
                else
                {
                    child.GetComponent<TextMeshProUGUI>().enabled = false;
                }

                count++;
            }
        }
    }

    public void CompleteQuestObjective(int index_quest, int index_objective)
    {
        quests[index_quest].CompleteObjective(index_objective);
    }
}
