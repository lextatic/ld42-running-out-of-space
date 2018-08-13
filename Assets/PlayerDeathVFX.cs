using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathVFX : MonoBehaviour
{
	[SerializeField]
	GameObject prefabParticles;

	private void OnEnable()
	{
		DeathTouch.PlayerDeath += HandlePlayerDeath;
	}

	private void OnDisable()
	{
		DeathTouch.PlayerDeath -= HandlePlayerDeath;
	}

	private void HandlePlayerDeath()
	{
		gameObject.SetActive(false);
		Instantiate(prefabParticles, this.transform.position, Quaternion.identity);
	}

}
