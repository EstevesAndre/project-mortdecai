using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMNS;
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    public void Start()
    {
        CreateDisplay();
    }

    public void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            InstantiateItem(i);
        }
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.container[i]))
            {
                itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            }
            else
            {
                InstantiateItem(i);
            }
        }
    }

    private void InstantiateItem(int itemIndex)
    {
        var obj = Instantiate(inventory.container[itemIndex].item.prefab, Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(itemIndex);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[itemIndex].amount.ToString("n0");
        itemsDisplayed.Add(inventory.container[itemIndex], obj);
    }

    private Vector3 GetPosition(int itemIndex)
    {
        return new Vector3(X_START + X_SPACE_BETWEEN_ITEMS * (itemIndex % NUMBER_OF_COLUMNS), Y_START + -Y_SPACE_BETWEEN_ITEMS * (itemIndex / NUMBER_OF_COLUMNS), 0f);
    }
}
