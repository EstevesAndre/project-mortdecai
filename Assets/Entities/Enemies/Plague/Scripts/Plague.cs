using UnityEngine;
using UnityEngine.AI;

public class Plague : DefaultEnemy
{
    #region Methods
    
    protected override void Start()
    {
        base.Start();
        stateMachine.SetState(new EnemyIdleState(this));
    }

    public override void PerformAttack()
    {
        // TODO
        Debug.Log("Perform Attack");
    }

    #endregion
}
