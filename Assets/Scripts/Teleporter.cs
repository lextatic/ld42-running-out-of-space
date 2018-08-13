using System;
using UnityEngine;
using UnityEngine.AI;

public class Teleporter : MonoBehaviour
{
	public Action<Collider> OnTeleportEntered;

	[SerializeField]
	private Transform outPosition;

	public Vector3 OutPosition
	{
		get { return outPosition.position; }
	}

	private void OnTriggerEnter(Collider other)
	{
		var navMeshAgent = other.GetComponent<NavMeshAgent>();
		if (navMeshAgent != null)
		{
			navMeshAgent.Warp(OutPosition);
		}
		else
		{
			other.transform.position = OutPosition;
		}
		OnTeleportEntered?.Invoke(other);
	}
}
