using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(LevelSetupVFX))]
public class LevelSetupVFXEditor : Editor
{
	public override void OnInspectorGUI()
	{
		EditorGUI.BeginDisabledGroup(!Application.isPlaying);
		if (GUILayout.Button("Test Shake"))
		{
			(target as LevelSetupVFX).PerformShake();
		}
		EditorGUI.EndDisabledGroup();

		base.OnInspectorGUI();
	}
}
#endif

public class LevelSetupVFX : MonoBehaviour
{
	Collectible[] collectibles;

	private void OnEnable()
	{
		collectibles = FindObjectsOfType<Collectible>();
		foreach (var collectible in collectibles)
		{
			collectible.OnObjectCollected += HandleObjectCollected;
		}
	}

	private void OnDisable()
	{
		foreach (var collectible in collectibles)
		{
			collectible.OnObjectCollected -= HandleObjectCollected;
		}
	}

	private void HandleObjectCollected(Collectible obj)
	{
		PerformShake();
	}

	[SerializeField]
	float impactScale = 1f;

	public void PerformShake()
	{
		ImpactForce.PerformOnChildren(this.transform, impactScale, 0.1f);
	}
}

static public class ImpactForce
{
	static public void PerformOnChildren(Transform transform, float distanceScale, float delayScale)
	{
		var playerPosition = GameObject.FindObjectOfType<CharacterMove>().transform.position;

		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			var childtransform = transform.GetChild(i);
			var distance = Vector3.Distance(playerPosition, childtransform.position);
			childtransform.DOLocalJump(childtransform.position, (1 / distance) * distanceScale, 1, 0.5f).SetDelay(distance * delayScale);
		}
	}

}