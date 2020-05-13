using UnityEngine;

public class PlagueMovingState : IStateEnemy
{
    #region Fields

    protected Plague owner;

    #endregion

    #region Constructor

    public PlagueMovingState(Plague _owner)
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
                owner.GetStateMachineEnemy().SetState(new PlagueAttackState(owner));
            }
            else if(owner.GetDistanceFromTarget() > 1f)
            {
                owner.GetTransform().LookAt(new Vector3(owner.GetTarget().transform.position.x, 0, 0));
                owner.GetTransform().position += owner.GetTransform().forward*owner.GetSpeed()*Time.deltaTime;
            }
        }
        else if(!owner.GetTargetInTerritory() && owner.GetDistanceFromInitialPos() > 1f)
        {
            owner.GetTransform().LookAt(owner.GetInitialPosition());
            owner.GetTransform().position += owner.GetTransform().forward*owner.GetSpeed()*Time.deltaTime;
        }
        else
        {
            owner.GetStateMachineEnemy().SetState(new PlagueIdleState(owner));
        }
    }

    public void Exit()
    {
        owner.GetAnimator().SetFloat("speed", 0.0f);
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