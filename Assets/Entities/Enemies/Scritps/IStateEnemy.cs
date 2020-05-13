using UnityEngine;

public interface IStateEnemy
{
    void Enter();
    void Execute();
    void Exit();
    void OnTriggerEnter(Collider collision);
    void OnTriggerExit(Collider collision);
}