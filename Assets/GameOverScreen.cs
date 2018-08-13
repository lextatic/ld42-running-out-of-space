using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
	[SerializeField]
	CanvasGroup canvas;

	bool playerIsDead = false;

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
		playerIsDead = true;
		canvas.DOFade(1f, 1f);
	}

	// Update is called once per frame
	void Update()
	{
		if (playerIsDead && Input.anyKeyDown)
		{
			SceneLoader.LoadScene("MainMenu");
		}
	}
}
