using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovingState : IState
{
    #region Fields

    private Player owner;

    #endregion

    #region Methods

    public PlayerMovingState(Player owner)
    {
        this.owner = owner;
    }
    public void Enter()
    {
        owner.GetInputSystem().Player2D.Interaction.started += Interact;
    }

    public void Execute()
    {
        if (owner.GetMovement().GetJump() > Mathf.Epsilon)
        {
            owner.GetStateMachine().SetState(new PlayerJumpingState(owner));
        }
        else if (owner.GetMovement().GetMovement() == Vector2.zero)
        {
            owner.GetStateMachine().SetState(new PlayerIdleState(owner));

        }
    }

    public void Exit()
    {
        // Debug.Log("exiting moving state");
        owner.GetInputSystem().Player2D.Interaction.started -= Interact;
    }

    public void OnTriggerEnter(Collider collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            owner.AddInteractableInRange(interactable);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            owner.RemoveInteractableInRange(interactable);
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact was called in moving state");
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
