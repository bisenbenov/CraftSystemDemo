using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}
		
		instance = this;
	}

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 20;  // может быть задано как число предметов в инвентаре,
							// подходящих для крафта (не установлен флажок ifDefault)

	public List<Item> items = new List<Item>();

	// Add a new item. If there is enough room we
	// return true. Else we return false.
	public void Add(Item item)
	{
		// Don't do anything if it's a default item
		if (!item.isDefaultItem) 
		{
			// Check if out of space
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return;
			}

			items.Add(item);    // Add item to list
			
			// Trigger callback
			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}
	}

	// Remove an item
	public void Remove(Item item)
	{
		items.Remove(item);     // Remove item from list

		// Trigger callback
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}