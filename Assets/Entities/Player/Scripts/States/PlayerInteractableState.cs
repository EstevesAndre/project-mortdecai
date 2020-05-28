using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerInteractableState : IState
{
    #region Fields

    protected Player owner;

    #endregion

    #region Constructor

    public PlayerInteractableState(Player _owner)
    {
        owner = _owner;
    }

    #endregion

    #region Methods

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();

    public void OnTriggerEnter(Collider collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            owner.AddInteractableInRange(collision.gameObject);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            owner.RemoveInteractableInRange(collision.gameObject);
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact was called" + owner.GetInteractablesInRange());
        if (owner.GetInteractablesInRange().Count >= 1)
        {
            GameObject toInteract = owner.GetInteractablesInRange()[0];
            if (toInteract != null)
            {
                Debug.Log("Going to interact with" + owner.GetInteractablesInRange());
                Item isItem = toInteract.GetComponent<Item>();
                if (isItem != null)
                {
                    Debug.Log("Interacting with an item");
                    owner.GetInventory().AddItem(isItem.item, 1);
                    Object.Destroy(toInteract);
                } else {
                    NPC isNPC = toInteract.GetComponent<NPC>();
                    if (isNPC != null)
                    {
                        Debug.Log("Interacting with an NPC");
                        isNPC.Interact(owner);
                    }
                }
                owner.RemoveInteractableInRange(toInteract);
            }

        }
    }

    #endregion


}
