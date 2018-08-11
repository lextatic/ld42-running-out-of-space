using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	public Action<Collectible> OnObjectCollected;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			OnObjectCollected?.Invoke(this);
			Destroy(gameObject);
		}
	}
}
