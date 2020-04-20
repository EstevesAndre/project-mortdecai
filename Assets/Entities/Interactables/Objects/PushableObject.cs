using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushableObject : MonoBehaviour, IInteractable
{
    #region Fields

    private Rigidbody body;

    #endregion

    #region Constructor

    public void Awake()
    {
        body = this.GetComponent<Rigidbody>();
    }

    #endregion

    #region Methods

    public void OnPush()
    {
        // TODO move the object
    }

    #endregion

    #region IInteractable Interface

    public void OnInteract(GameObject entity)
    {
        OnPush();
    }

    public void OnRange()
    {
        // TODO Display some sort of HUD indicating the item in question
    }

    public void OutOfRange()
    {
        // TODO Display some sort of HUD indicating the item in question
    }

    #endregion
}
