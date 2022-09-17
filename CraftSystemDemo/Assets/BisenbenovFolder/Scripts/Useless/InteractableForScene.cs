using UnityEngine;

public class InteractableForScene : MonoBehaviour
{
	//public float radius = 3f;               
	public Transform interactionTransform;  

	bool isFocus = false;  
	Transform player;      

	bool hasInteracted = false;

	public virtual void Interact()
	{
	}

	void Update()
	{
		// ּועמה נאסרטנÿולûי
	}

	// Called when the object starts being focused
	public void OnFocused(Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	// Called when the object is no longer focused
	public void OnDefocused()
	{
		isFocus = false;
		player = null;
		hasInteracted = false;
	}
}
