using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	public Action<Collectible> OnObjectCollected = delegate { };

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			OnObjectCollected?.Invoke(this);
			Destroy(gameObject);
		}
	}
}
