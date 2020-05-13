using UnityEngine;

public class PlagueAttackState : IStateEnemy
{
    #region Fields

    protected Plague owner;

    #endregion

    #region Constructor

    public PlagueAttackState(Plague _owner)
    {
        owner = _owner;
    }

    #endregion

    #region Methods

    public void Enter()
    {

    }

    public void Execute()
    {
        if (owner.InRangeToAttack())
        {
            Debug.Log(owner.GetTimeToAttack());

            if (owner.GetTimeToAttack() > 0)
            {
                owner.DecreaseTimeToAttack(Time.deltaTime);
                owner.GetAnimator().SetBool("attack", false);
            }
            else
            {
                // TODO do something to the target
                owner.GetAnimator().SetBool("attack", true);
                owner.ResetTimeToAttack();
            }
        }
        else
        {
            owner.GetStateMachineEnemy().SetState(new PlagueMovingState(owner));
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