using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IPlayableEntity, IInventorySystem
{

    #region Fields

    private StateMachine stateMachine = new StateMachine();
    private PlayerMovement movement;

    #endregion

    #region IInventorySystem Interface

    public void PlaceInInventory(CollectibleType item)
    {
        Debug.Log("Placed item in inventory: " + item);
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

    public PlayerMovement GetMovement()
    {
        return movement;
    }

    public StateMachine GetStateMachine()
    {
        return stateMachine;
    }

    #endregion
}
