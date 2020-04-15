using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Text))]
public class SimplePrompt : MonoBehaviour, IToggableUI
{

    #region Fields

    private Text text;
    private Image image;

    #endregion

    #region Methods

    public void Enable()
    {
        text.enabled = true;
        image.enabled = true;
    }

    public void Disable()
    {
        text.enabled = false;
        image.enabled = false;
    }

    #endregion

}
