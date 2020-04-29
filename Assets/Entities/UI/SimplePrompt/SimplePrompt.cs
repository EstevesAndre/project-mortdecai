using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePrompt : MonoBehaviour, IToggableUI
{

    #region Fields

    #endregion

    #region Methods

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    #endregion

}
