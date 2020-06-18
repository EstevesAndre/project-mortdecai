using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChanger : MonoBehaviour {
    public int zone1;
    public int zone2;
    public QuestManager questManager;

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Mortdecai")) {
             if(questManager.zone == zone1) {
                    questManager.setZone(zone2);
                } else {
                    questManager.setZone(zone1);
                }
        }
    }
}
