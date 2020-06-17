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

    private void Erase()
    {
        itemsDisplayed.Clear();

        foreach(Transform child in transform) 
        {
            Destroy(child.gameObject);
        }
    }


    private void UpdateDisplay()
    {
        Erase();

        for (int i = 0, j = 0; i < inventory.container.Count; i++)
        {
            if (inventory.container[i].amount != 0) {
                InstantiateItem(i);
            }
        }
    }

    private void InstantiateItem(int itemIndex)
    {
        var obj = Instantiate(inventory.container[itemIndex].item.prefab, Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(itemsDisplayed.Count);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[itemIndex].amount.ToString("n0");
        itemsDisplayed.Add(inventory.container[itemIndex], obj);
    }

    private Vector3 GetPosition(int itemIndex)
    {
        return new Vector3(X_START + X_SPACE_BETWEEN_ITEMS * (itemIndex % NUMBER_OF_COLUMNS), Y_START + -Y_SPACE_BETWEEN_ITEMS * (itemIndex / NUMBER_OF_COLUMNS), 0f);
    }
}
