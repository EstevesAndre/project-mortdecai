using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    // unity syntaxe, callback to be overwritten
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<Item2> items = new List<Item2>();


    void Start()
    {

        // Dummy items 
        // TODO to be removed
        items.Add(ScriptableObject.CreateInstance<Item2>());
        items.Add(ScriptableObject.CreateInstance<Item2>());
        items.Add(ScriptableObject.CreateInstance<Item2>());
        items.Add(ScriptableObject.CreateInstance<Item2>());

    }

    // Add a new item if enough room
    public void Add(Item2 item)
    {
        if (item.showInInventory)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    // Remove an item
    public void Remove(Item2 item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}