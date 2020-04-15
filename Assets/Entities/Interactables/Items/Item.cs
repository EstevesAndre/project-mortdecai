using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType { Feather }

[RequireComponent(typeof(Canvas))]
public class Item : MonoBehaviour, IInteractable, IHasUIPrompt
{
    #region Fields

    private CollectibleType type;
    private SimplePrompt prompt;
    private Canvas canvas;

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
        // Add prompt to canvas
        prompt.gameObject.transform.SetParent(canvas.gameObject.transform);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IPlayableEntity>() != null)
        {
            ShowPrompt();
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<IPlayableEntity>() != null)
        {
            HidePrompt();
        }
    }

    #endregion
}
