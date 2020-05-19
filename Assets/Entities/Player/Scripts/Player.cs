using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IPlayableEntity
{

    #region Fields

    private StateMachine stateMachine = new StateMachine();
    private PlayerMovement movement;
    private List<GameObject> interactablesInRange = new List<GameObject>();
    [SerializeField]
    private InventoryObject inventory;

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

    public List<GameObject> GetInteractablesInRange()
    {
        return interactablesInRange;
    }

    public InventoryObject GetInventory()
    {
        return inventory;
    }

    public Input GetInputSystem()
    {
        return movement.GetControls();
    }

    #endregion

    #region Interactables

    public void AddInteractableInRange(GameObject interactable)
    {
        Debug.Log("Adding interactable in range");
        interactablesInRange.Add(interactable);
    }

    public void RemoveInteractableInRange(GameObject interactable)
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

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
    #endregion
}
