using UnityEngine;

public class PlagueIdleState : IStateEnemy
{
    #region Fields

    protected Plague owner;

    #endregion

    #region Constructor

    public PlagueIdleState(Plague _owner)
    {
        owner = _owner;
    }

    #endregion

    #region Methods

    public void Enter()
    {
        owner.GetAnimator().SetFloat("speed", 0.0f);
    }

    public void Execute()
    {
        if(owner.GetTargetInTerritory())
        {
            owner.GetStateMachineEnemy().SetState(new PlagueMovingState(owner));
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == owner.GetTarget() && !owner.GetTargetInTerritory())
        {
            owner.SetTargetInTerritory(true);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject == owner.GetTarget())
        {
            owner.SetTargetInTerritory(false);
        }
    }

    #endregion
}