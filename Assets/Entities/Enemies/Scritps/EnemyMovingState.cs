using UnityEngine;

public class EnemyMovingState : IStateEnemy
{
    #region Fields

    protected DefaultEnemy owner;

    #endregion

    #region Constructor

    public EnemyMovingState(DefaultEnemy _owner)
    {
        owner = _owner;
    }

    #endregion

    #region Methods

    public void Enter()
    {
        owner.GetAnimator().SetFloat("speed", 1.0f);
    }

    public void Execute()
    {
        if (owner.GetTargetInTerritory())
        {
            if(owner.InRangeToAttack())
            {
                owner.GetStateMachineEnemy().SetState(new EnemyAttackState(owner));
            }
            else if(owner.GetDistanceFromTarget() > 1f)
            {
                owner.GetAgent().SetDestination(owner.GetTarget().transform.position);
            }
        }
        else if(!owner.GetTargetInTerritory() && owner.GetDistanceFromInitialPos() > 1f)
        {
            owner.GetAgent().SetDestination(owner.GetInitialPosition());
        }
        else
        {
            owner.GetStateMachineEnemy().SetState(new EnemyIdleState(owner));
        }
    }

    public void Exit()
    {
        owner.GetAnimator().SetFloat("speed", 0.0f);
        owner.GetAgent().isStopped = true;
        owner.GetAgent().ResetPath();
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