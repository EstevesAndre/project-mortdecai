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
        IInventorySystem inv = entity.GetComponent<IInventorySystem>();
        if (inv != null)
        {
            inv.PlaceInInventory(type);
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
        // Add prompt to canvas
        prompt.gameObject.transform.SetParent(canvas.gameObject.transform);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IPlayableEntity>() != null)
        {
            OnRange();
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<IPlayableEntity>() != null)
        {
            OutOfRange();
        }
    }

    #endregion
}
