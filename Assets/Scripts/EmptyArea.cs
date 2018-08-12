using System;
using UnityEngine;

public class EmptyArea : MonoBehaviour
{
	public Action OnAreaEmptied;

	private int objectsInsideCount = 0;

	bool collected = false;

	[SerializeField]
	Collectible myCollectible;

	private void OnEnable()
	{
		myCollectible.OnObjectCollected += OnObjectCollected;
	}

	private void OnDisable()
	{
		myCollectible.OnObjectCollected -= OnObjectCollected;
	}

	private void OnTriggerEnter(Collider other)
	{
		objectsInsideCount++;
	}

	void OnObjectCollected(Collectible collectible)
	{
		collected = true;
		SubtractAndCheck();
	}

	private void OnTriggerExit(Collider other)
	{
		SubtractAndCheck();
	}

	private void SubtractAndCheck()
	{
		objectsInsideCount--;
		if (objectsInsideCount == 0 && collected)
		{
			OnAreaEmptied?.Invoke();
			Destroy(gameObject);
		}
	}
}
