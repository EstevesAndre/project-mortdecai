using UnityEngine;
using UnityEngine.AI;

public class Plague : MonoBehaviour
{
    #region Fields

    private StateMachineEnemy stateMachine = new StateMachineEnemy();
    private Vector3 initialPosition;
    private Animator animator;
    public GameObject target;
    public float speed;
    public float damageOnHit; // assuming each enemy has only one hability
    
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

    public float GetSpeed()
    {
        return speed;
    }

    public float GetDamageOnHit()
    {
        return damageOnHit;
    }

    #endregion

    #region Methods
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        stateMachine.SetState(new PlagueIdleState(this));
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
