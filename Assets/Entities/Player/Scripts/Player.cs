using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IPlayableEntity, IInventorySystem
{

    #region Fields

    private StateMachine stateMachine = new StateMachine();
    private PlayerMovement movement;
    private List<IInteractable> interactablesInRange = new List<IInteractable>();

    #endregion

    #region IInventorySystem Interface

    public void PlaceInInventory(CollectibleType item)
    {
        Debug.Log("Placed item in inventory: " + item);
    }

    #endregion

    #region Getters and Setters

    public PlayerMovement GetMovement()
    {
        return movement;
    }

    public StateMachine GetStateMachine()
    {
        return stateMachine;
    }

    public List<IInteractable> GetInteractablesInRange()
    {
        return interactablesInRange;
    }

    public void AddInteractableInRange(IInteractable interactable)
    {
        interactablesInRange.Add(interactable);
    }

    public void RemoveInteractableInRange(IInteractable interactable)
    {
        interactablesInRange.Remove(interactable);
    }

    #endregion

    #region Methods

    public void Start()
    {
        movement = GetComponent<PlayerMovement>();
        stateMachine.SetState(new PlayerIdleState(this));
    }

    public void Update()
    {
        stateMachine.Update();
    }

    public void OnTriggerEnter(Collider collision)
    {
        stateMachine.OnTriggerEnter(collision);
    }

    public void OnTriggerExit(Collider collision)
    {
        stateMachine.OnTriggerExit(collision);
    }

    #endregion
}
