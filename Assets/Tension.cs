﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Tension : MonoBehaviour
{
	[SerializeField]
	PostProcessVolume postProcess;

	ChromaticAberration chromatic;

	Vignette vignette;
	EnemyMove[] enemies;

	[SerializeField]
	float vignetteFactor = 1;

	[SerializeField]
	float maxDistance;

	// Use this for initialization
	void Start()
	{
		postProcess.profile.TryGetSettings(out vignette);
		postProcess.profile.TryGetSettings(out chromatic);
		enemies = FindObjectsOfType<EnemyMove>();
	}

	// Update is called once per frame
	void Update()
	{
		float closestEnemy = maxDistance + 1;
		foreach (var enemy in enemies)
		{
			float dist = Vector3.Distance(this.transform.position, enemy.transform.position);
			if (dist < maxDistance && closestEnemy > dist)
			{
				closestEnemy = dist;
			}
		}

		float distanceRatio = closestEnemy / maxDistance;
		float finalRatio = 1 - (distanceRatio * vignetteFactor);

		vignette.intensity.value = finalRatio;
		chromatic.intensity.value = finalRatio;
	}
}
