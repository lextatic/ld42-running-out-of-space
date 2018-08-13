using System;
using UnityEngine;

public class EmptyArea : MonoBehaviour
{
	private bool collected = false;

	private bool playerInside = false;

	[SerializeField]
	private Collectible myCollectible;

	private int ghostsInside = 0;

	public event Action GhostsCleared = delegate { };

	public event Action FloorFall = delegate { };

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
		if (other.CompareTag("Player"))
		{
			playerInside = true;
			return;
		}

		ghostsInside++;
	}

	void OnObjectCollected(Collectible collectible)
	{
		collected = true;
		//Check();
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerInside = false;
			if (collected)
			{
				FloorFall();
			}
			return;
		}

		ghostsInside--;
		if (collected && ghostsInside == 0)
		{
			GhostsCleared();
		}

		Check();
	}

	private void Check()
	{
		if (!playerInside && ghostsInside == 0 && collected)
		{
			//Destroy(gameObject);
		}
	}
}
