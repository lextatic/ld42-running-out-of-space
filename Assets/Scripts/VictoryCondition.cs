using System;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
	public Action<bool> OnVictory;

	public static VictoryCondition Instance;

	private List<Collectible> collectibleList;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		collectibleList = new List<Collectible>(FindObjectsOfType<Collectible>());
		foreach (var collectible in collectibleList)
		{
			collectible.OnObjectCollected += OnObjectColleced;
		}
	}

	private void OnObjectColleced(Collectible collectible)
	{
		collectibleList.Remove(collectible);

		if (collectibleList.Count == 0)
		{
			OnVictory?.Invoke(true);
		}
	}
}
