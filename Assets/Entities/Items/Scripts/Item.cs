  
using UnityEngine;

public class Item : MonoBehaviour {
    
	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool showInInventory = true;

    public void Use ()
	{
		// Use the item
		// Something may happen
	}
}