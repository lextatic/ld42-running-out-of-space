using System;
using UnityEngine;

public class EmptyArea : MonoBehaviour
{
	public Action OnAreaEmptied;

	private int objectsInsideCount = 0;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("EmptyArea TriggerEnter");
		objectsInsideCount++;
		var collectible = other.GetComponent<Collectible>();
		if(collectible != null)
		{
			collectible.OnObjectCollected = OnObjectCollected;
		}
	}

	void OnObjectCollected(Collectible collectible)
	{
		Debug.Log("EmptyArea ObjectCollected");
		SubtractAndCheck();
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("EmptyArea TriggerExit");
		SubtractAndCheck();
	}

	private void SubtractAndCheck()
	{
		objectsInsideCount--;
		if (objectsInsideCount == 0)
		{
			OnAreaEmptied?.Invoke();
			Destroy(gameObject);
		}
	}
}
