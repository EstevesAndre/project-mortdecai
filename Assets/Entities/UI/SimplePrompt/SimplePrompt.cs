using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePrompt : MonoBehaviour, IToggableUI
{

    #region Fields

    public string valueToDisplay;
    private Text display;

    #endregion

    #region Methods

    public void Start()
    {
        display = transform.GetChild(0).transform.GetComponent<Text>();
        display.text = valueToDisplay;
    }

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
