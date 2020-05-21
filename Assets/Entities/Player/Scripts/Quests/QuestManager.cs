using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public Player player;
    private int questIndex;
    private List<Quest> quests;
    private bool finished;
    public int zone;
    
    // Start is called before the first frame update
    void Start()
    {
        quests = new List<Quest>();

        quests.Add(new Quest(
            transform,
            1,
            "Quest 1",
            new List<QuestObjective>() {
                new CollectObjective(transform, 1, "Find mushrooms", 1, "strawberry"),
                new CollectObjective(transform, 2, "Find invisibility feather", 1, "invisibilityFeather")
            }
        ));
        quests.Add(new Quest(
            transform,
            2,
            "Quest 1",
            new List<QuestObjective>() {
                new CollectObjective(transform, 1, "Find mushrooms", 1, "strawberry"),
                new CollectObjective(transform, 2, "Find invisibility feather", 1, "invisibilityFeather")
            }
        ));
        Debug.Log(quests.Count);
        
        questIndex = 0;
        zone = 1;
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Print All quests are completed
        if (quests.Count == questIndex)
        {
            if (finished) {
                return;
            }

            int count = 1;
            foreach (Transform child in transform) {

                if(count == transform.childCount) {
                    child.GetComponent<TextMeshProUGUI>().enabled = true;
                }
                else {
                    child.GetComponent<TextMeshProUGUI>().enabled = false;
                }

                count++;
            }
            finished = true;
        }
        else if (!quests[questIndex].isCompleted)
        {
            quests[questIndex].UpdateUI(player);
        }
        else
        {
            if (questIndex + 1 >= quests.Count)
            {
                questIndex++;
            }
            else if (quests[questIndex + 1].zone == zone)
            {
                Debug.Log("HERE");
                questIndex++;
            }
        }
    }
}
