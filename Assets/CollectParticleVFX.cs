using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectParticleVFX : MonoBehaviour
{
	[SerializeField]
	ParticleSystem Particle;

	[SerializeField]
	Collectible collectible;

	private void Start()
	{
		collectible.OnObjectCollected += HandleObjectCollected;
	}

	private void OnDestroy()
	{
		collectible.OnObjectCollected -= HandleObjectCollected;
	}

	private void HandleObjectCollected(Collectible obj)
	{
		Instantiate(Particle, this.transform.position, Quaternion.identity);
	}
}
