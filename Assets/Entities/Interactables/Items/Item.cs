using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CollectibleType { Feather, Mushroom, Key }

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour, IInteractable, IHasUIPrompt
{
    #region Fields

    public InventoryItem inventoryItem;
    public CollectibleType type;
    public SimplePrompt prompt;
    public Canvas canvas; // TODO

    #endregion

    #region IInteractable Interface

    public void OnInteract(GameObject entity)
    {
        Debug.Log("OnInteract of item called");
        IInventorySystem inv = entity.GetComponent<IInventorySystem>();
        if (inv != null)
        {
            inv.PlaceInInventory(inventoryItem);
        }
        Destroy(gameObject);
    }

    public void OnRange()
    {
        ShowPrompt();
    }

    public void OutOfRange()
    {
        HidePrompt();
    }

    #endregion

    #region IHasUIPrompt Interface

    public void ShowPrompt()
    {
        prompt.Enable();
    }

    public void HidePrompt()
    {
        prompt.Disable();
    }

    #endregion

    #region Methods

    public void Start()
    {
        // TODO
        // Add prompt to canvas
        // prompt.gameObject.transform.SetParent(canvas.gameObject.transform);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<IPlayableEntity>() != null)
        {
            OnRange();
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<IPlayableEntity>() != null)
        {
            OutOfRange();
        }
    }

    #endregion
}
