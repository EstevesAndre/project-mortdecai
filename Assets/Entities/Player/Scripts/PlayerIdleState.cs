using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : IState
{
    #region Fields

    private Player owner;

    #endregion

    #region Methods

    public PlayerIdleState(Player owner)
    {
        this.owner = owner;
    }
    public void Enter()
    {
        owner.GetInputSystem().Player2D.Interaction.started += Interact;
    }

    public void Execute()
    {
        if (owner.GetMovement().GetMovement() != Vector2.zero)
        {
            owner.GetStateMachine().SetState(new PlayerMovingState(owner));
        }
        else if (owner.GetMovement().GetJump() > Mathf.Epsilon)
        {
            owner.GetStateMachine().SetState(new PlayerJumpingState(owner));
        }
    }

    public void Exit()
    {
        owner.GetInputSystem().Player2D.Interaction.started -= Interact;
    }

    public void OnTriggerEnter(Collider collision)
    {

    }

    public void OnTriggerExit(Collider collision)
    {

    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact was called in idle state: " + owner.GetInteractablesInRange().Count);
        if (owner.GetInteractablesInRange().Count >= 1)
        {
            IInteractable toInteract = owner.GetInteractablesInRange()[0];
            if (toInteract != null)
            {
                toInteract.OnInteract(owner.gameObject);
                owner.RemoveInteractableInRange(toInteract);
            }
        }
    }

    #endregion

}
