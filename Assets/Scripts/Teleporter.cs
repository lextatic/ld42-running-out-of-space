using System;
using UnityEngine;

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
		other.transform.position = OutPosition;
		OnTeleportEntered?.Invoke(other);
	}
}
