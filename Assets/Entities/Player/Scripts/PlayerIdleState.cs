using UnityEngine;

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
        Debug.Log("entering idle state");
        owner.GetInputSystem().Player2D.Interaction.performed += _ => Interact();
    }

    public void Execute()
    {
        Debug.Log("updating idle state");
        Debug.Log(owner.GetMovement().GetMovement());
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
        Debug.Log("exiting idle state");
    }

    public void OnTriggerEnter(Collider collision)
    {

    }

    public void OnTriggerExit(Collider collision)
    {

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
