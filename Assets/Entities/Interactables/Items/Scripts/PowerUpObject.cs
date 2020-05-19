using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power Up Object", menuName = "InventorySystem/Items/PowerUp")]
public class PowerUpObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.PowerUp;
    }
}
