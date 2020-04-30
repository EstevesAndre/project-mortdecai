using UnityEngine;

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
        Debug.Log("entering moving state");
        owner.GetInputSystem().Player2D.Interaction.performed += _ => Interact();
    }

    public void Execute()
    {
        Debug.Log("updating moving state");
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
        Debug.Log("exiting moving state");
    }

    public void OnTriggerEnter(Collider collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            Debug.Log("Interactable in range: " + interactable);
            owner.AddInteractableInRange(interactable);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            Debug.Log("Interactable out of range: " + interactable);
            owner.RemoveInteractableInRange(interactable);
        }
    }

    public void Interact()
    {
        if (owner.GetInteractablesInRange()[0] != null)
        {
            owner.GetInteractablesInRange()[0].OnInteract(owner.gameObject);
        }
    }

    #endregion
}
