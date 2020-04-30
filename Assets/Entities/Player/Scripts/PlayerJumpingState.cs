using UnityEngine;

public class PlayerJumpingState : IState
{
    #region Fields

    private Player owner;

    #endregion

    #region Methods

    public PlayerJumpingState(Player owner)
    {
        this.owner = owner;
    }
    public void Enter()
    {
        Debug.Log("entering idle state");
    }

    public void Execute()
    {
        Debug.Log("updating idle state");
        if (owner.GetMovement().GetJump() <= Mathf.Epsilon)
        {
            owner.GetStateMachine().SetState(new PlayerIdleState(owner));
        }
    }

    public void Exit()
    {
        Debug.Log("exiting idle state");
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

    #endregion
}
