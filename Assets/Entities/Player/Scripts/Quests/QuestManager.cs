using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Player player;
    private int questIndex;
    private List<Quest> quests;

    // Start is called before the first frame update
    void Start()
    {
        quests = new List<Quest>();

        quests.Add(new Quest(
            "Quest 1",
            new List<QuestObjective>() {
                new CollectObjective("Find mushrooms", 3, "mushroom"),
                new CollectObjective("Find invisibility feather", 1, "invisibilityFeather")
            }
        ));
        
        questIndex = 0;
    }

    

    // Update is called once per frame
    void Update()
    {
        // TODO
        quests[questIndex].Update(player);
    }
}
