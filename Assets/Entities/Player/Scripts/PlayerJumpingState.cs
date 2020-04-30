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

    #endregion
}
