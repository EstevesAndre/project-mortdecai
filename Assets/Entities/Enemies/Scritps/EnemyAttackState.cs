using UnityEngine;

public class EnemyAttackState : IStateEnemy
{
    #region Fields

    protected DefaultEnemy owner;

    #endregion

    #region Constructor

    public EnemyAttackState(DefaultEnemy _owner)
    {
        owner = _owner;
    }

    #endregion

    #region Methods

    public void Enter()
    {
        owner.GetTransform().LookAt(new Vector3(owner.GetTarget().transform.position.x, 0, 0));
    }

    public void Execute()
    {
        if (owner.InRangeToAttack())
        {
            owner.GetTransform().LookAt(new Vector3(owner.GetTarget().transform.position.x, 0, 0));

            if (owner.GetTimeToAttack() > 0)
            {
                owner.DecreaseTimeToAttack(Time.deltaTime);
                owner.GetAnimator().SetBool("attack", false);
            }
            else
            {
                owner.GetAnimator().SetBool("attack", true);
                owner.PerformAttack();
                owner.ResetTimeToAttack();
            }
        }
        else
        {
            owner.GetStateMachineEnemy().SetState(new EnemyMovingState(owner));
        }
    }

    public void Exit()
    {
        owner.GetAnimator().SetBool("attack", false);
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