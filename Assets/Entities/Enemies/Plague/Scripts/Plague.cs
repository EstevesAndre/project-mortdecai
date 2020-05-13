using UnityEngine;
using UnityEngine.AI;

public class Plague : MonoBehaviour
{
    #region Fields

    private StateMachineEnemy stateMachine = new StateMachineEnemy();
    private Vector3 initialPosition;
    private Animator animator;
    private float timeToAttack;
    private bool targetInTerritory;
    public GameObject target;
    public float speed;
    public float attackRange;
    public float damageOnHit; // assuming each enemy has only one hability
    public float attackRate; // time between two attacks
    
    #endregion


    #region Getters and Setters

    public StateMachineEnemy GetStateMachineEnemy()
    {
        return stateMachine;
    }

    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public bool GetTargetInTerritory()
    {
        return targetInTerritory;
    }

    public void SetTargetInTerritory(bool _bool)
    {
        targetInTerritory = _bool;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetDamageOnHit()
    {
        return damageOnHit;
    }

    public float GetDistanceFromTarget()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }
    
    public float GetDistanceFromInitialPos()
    {
        return Vector3.Distance(initialPosition, transform.position);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public bool InRangeToAttack()
    {
        return Vector3.Distance(transform.position, target.transform.position) <= attackRange;
    }

    public float GetAttackRate()
    {
        return attackRate;
    }

    public float GetTimeToAttack()
    {
        return timeToAttack;
    }

    public void DecreaseTimeToAttack(float decreaseTime)
    {
        timeToAttack -= decreaseTime;
    }

    public void ResetTimeToAttack()
    {
        timeToAttack = attackRate;
    }

    #endregion

    #region Methods
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        stateMachine.SetState(new PlagueIdleState(this));
        timeToAttack = 0f;
    }

    public void Update()
    {
        stateMachine.Update();
    }

    public void OnTriggerEnter(Collider collision)
    {
        stateMachine.OnTriggerEnter(collision);
    }

    public void OnTriggerExit(Collider collision)
    {
        stateMachine.OnTriggerExit(collision);
    }

    #endregion
}
