using System;
using UnityEngine;

public class EmptyArea : MonoBehaviour
{
	public Action OnAreaEmptied;

	private int objectsInsideCount = 0;

	private void OnTriggerEnter(Collider other)
	{
		objectsInsideCount++;
		var collectible = other.GetComponent<Collectible>();
		if(collectible != null)
		{
			collectible.OnObjectCollected += OnObjectCollected;
		}
	}

	void OnObjectCollected(Collectible collectible)
	{
		SubtractAndCheck();
	}

	private void OnTriggerExit(Collider other)
	{
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
