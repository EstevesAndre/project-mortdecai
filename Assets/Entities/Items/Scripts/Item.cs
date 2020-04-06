using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 0)]
public class Item : ScriptableObject {
    
	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool showInInventory = true;

    public void Use ()
	{
		// Use the item
		// Something may happen
	}
}