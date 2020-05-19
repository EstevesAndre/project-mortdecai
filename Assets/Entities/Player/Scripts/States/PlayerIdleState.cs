using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerInteractableState
{

    #region Methods

    public PlayerIdleState(Player _owner) : base(_owner) { }
    public override void Enter()
    {
        owner.GetInputSystem().Player2D.Interaction.started += Interact;
    }

    public override void Execute()
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

    public override void Exit()
    {
        owner.GetInputSystem().Player2D.Interaction.started -= Interact;
    }

    #endregion

}
