using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	[SerializeField]
	private SimpleAudioEvent collectedSound;

	[SerializeField]
	private AudioSource audioSource;
	
	public Action<Collectible> OnObjectCollected = delegate { };

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			OnObjectCollected?.Invoke(this);
			collectedSound.Play(audioSource);
			Destroy(gameObject);
		}
	}
}
