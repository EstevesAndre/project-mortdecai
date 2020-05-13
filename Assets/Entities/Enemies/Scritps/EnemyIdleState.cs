using UnityEngine;

public class EnemyIdleState : IStateEnemy
{
    #region Fields

    protected DefaultEnemy owner;

    #endregion

    #region Constructor

    public EnemyIdleState(DefaultEnemy _owner)
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
            owner.GetStateMachineEnemy().SetState(new EnemyMovingState(owner));
        }
        else if(owner.InRangeToAttack())
        {
            owner.GetStateMachineEnemy().SetState(new EnemyAttackState(owner));
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