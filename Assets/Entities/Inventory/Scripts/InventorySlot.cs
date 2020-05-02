using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    #region Fields

    private InventoryItem item;
    public Image icon;

    #endregion

    #region Methods

    public void AddItem(InventoryItem item)
    {
        Debug.Log("Adding item to inventory slot");
        this.item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    #endregion
}
