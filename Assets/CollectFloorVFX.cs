using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectFloorVFX : MonoBehaviour
{

	[SerializeField]
	Transform floorsParent;

	List<Floor> floors;

	[SerializeField]
	Collectible collectible;

	private void Start()
	{
		collectible.OnObjectCollected += HandleObjectCollected;

		floors = new List<Floor>(floorsParent.GetComponentsInChildren<Floor>());
		floors.OrderBy(item => Vector3.Distance(item.transform.position, this.transform.position));
	}

	private void OnDestroy()
	{
		collectible.OnObjectCollected -= HandleObjectCollected;
	}

	private void HandleObjectCollected(Collectible obj)
	{
		Debug.Log("Collected");
		foreach (var floor in floors)
		{
			floor.gameObject.AddComponent<FloorBlinkVFX>().SetDelay(Vector3.Distance(this.transform.position, floor.transform.position) * 0.06125f);
		}
	}
}
