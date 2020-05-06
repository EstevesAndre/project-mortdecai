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

    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        
    }

    public void OnTriggerExit(Collider collision)
    {
        
    }

    #endregion
}