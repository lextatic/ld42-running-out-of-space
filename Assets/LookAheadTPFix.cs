using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class LookAheadTPFix : MonoBehaviour
{
	[SerializeField]
	CinemachineVirtualCamera cam;
	[SerializeField]
	CinemachineComposer composer;

	Coroutine restoreCoroutine;

	[SerializeField]
	Teleporter[] teleporters;

	private void Awake()
	{
		cam = GetComponent<CinemachineVirtualCamera>();
		composer = cam.GetCinemachineComponent<CinemachineComposer>();
	}

	private void Start()
	{
		foreach (var tp in teleporters)
		{
			tp.OnTeleportEntered += HandleTeleport;
		}
	}

	private void OnDestroy()
	{
		foreach (var tp in teleporters)
		{
			tp.OnTeleportEntered -= HandleTeleport;
		}
	}

	private void HandleTeleport(Collider obj)
	{
		if (obj.GetComponent<CharacterMove>() == null)
		{
			return;
		}

		composer.m_LookaheadTime = 0f;

		if (restoreCoroutine != null)
		{
			StopCoroutine(restoreCoroutine);
		}

		restoreCoroutine = StartCoroutine(Restore());

	}

	IEnumerator Restore()
	{
		yield return new WaitForSeconds(0.5f);
		composer.m_LookaheadTime = 0.3f;
	}
}
