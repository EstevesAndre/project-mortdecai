using UnityEngine;

public class StateMachineEnemy
{
    IStateEnemy currentState;

    public void SetState(IStateEnemy newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null) currentState.Execute();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (currentState != null) currentState.OnTriggerEnter(collision);
    }

    public void OnTriggerExit(Collider collision)
    {
        if (currentState != null) currentState.OnTriggerExit(collision);
    }
}