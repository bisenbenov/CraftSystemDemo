using UnityEngine;

public class ItemPickup : InteractableForScene
{
	public Item item;   // Item to put in the inventory on pickup

	public override void Interact()
	{
		base.Interact();

		PickUp();   // Pick it up!
	}
	
	void PickUp()
	{
		Inventory.instance.Add(item);    // Add to inventory
	}

}
