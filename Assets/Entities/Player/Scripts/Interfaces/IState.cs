using UnityEngine;

public interface IState
{
    void Enter();
    void Execute();
    void Exit();
    void OnTriggerEnter(Collider collision);
    void OnTriggerExit(Collider collision);
}
