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

    #endregion
}
