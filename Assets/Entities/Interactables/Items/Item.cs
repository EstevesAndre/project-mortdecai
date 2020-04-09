using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType { Feather }

public class Item : MonoBehaviour, IInteractable
{
    #region Fields

    private CollectibleType type;

    #endregion

    #region IInteractable Interface

    public void OnInteract(GameObject entity)
    {
        // send a message to the game manager saying that the player should collect an item of this type and put it in their inventory
        IInventorySystem inv = entity.GetComponent<IInventorySystem>();
        if (inv != null)
        {
            inv.PlaceInInventory(type);
        }
        Destroy(gameObject);
    }

    public void OnRange()
    {
        // TODO Display some sort of HUD indicating the item in question
    }

    #endregion
}
