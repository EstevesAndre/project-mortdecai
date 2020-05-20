using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovingState : PlayerInteractableState
{
    #region Methods

    public PlayerMovingState(Player _owner) : base(_owner) { }
    public override void Enter()
    {
        owner.GetInputSystem().Player2D.Interaction.started += Interact;
    }

    public override void Execute()
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

    public override void Exit()
    {
        // Debug.Log("exiting moving state");
        owner.GetInputSystem().Player2D.Interaction.started -= Interact;
    }

    #endregion
}
