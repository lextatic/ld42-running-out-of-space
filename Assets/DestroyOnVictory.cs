using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnVictory : MonoBehaviour
{
	[SerializeField]
	GameObject explosionPrefab;

	VictoryCondition victory;

	private void OnEnable()
	{
		victory = FindObjectOfType<VictoryCondition>();
		victory.OnVictory += HandleGameFinished;
	}

	private void OnDisable()
	{
		victory.OnVictory -= HandleGameFinished;
	}

	private void HandleGameFinished(bool obj)
	{
		if (obj)
		{
			Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
			GameObject.Destroy(this.gameObject);
		}
	}
}
