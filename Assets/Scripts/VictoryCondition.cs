using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
	[SerializeField]
	private List<Collectible> collectibleList;

	private void Start()
	{
		foreach(Collectible collectible in collectibleList)
		{
			collectible.OnObjectCollected += OnObjectColleced;
		}
	}

	private void OnObjectColleced(Collectible collectible)
	{
		collectibleList.Remove(collectible);

		if(collectibleList.Count == 0)
		{
			Debug.Log("Victory!");
			// TODO: Load next scene
		}
	}
}
