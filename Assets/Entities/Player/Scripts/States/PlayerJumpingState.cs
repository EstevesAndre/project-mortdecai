using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpingState : PlayerInteractableState
{
    #region Methods

    public PlayerJumpingState(Player _owner) : base(_owner) { }
    public override void Enter()
    {
        owner.GetInputSystem().Player2D.Interaction.started += Interact;
    }

    public override void Execute()
    {
        if (owner.GetMovement().GetJump() <= Mathf.Epsilon)
        {
            owner.GetStateMachine().SetState(new PlayerIdleState(owner));
        }
    }

    public override void Exit()
    {
        owner.GetInputSystem().Player2D.Interaction.started -= Interact;
    }

    #endregion
}
