using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
	[SerializeField]
	CanvasGroup canvas;

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
		canvas.DOFade(1f, 1f);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.anyKeyDown && canvas.alpha == 1)
		{
			SceneLoader.LoadScene("MainMenu");
		}
	}
}
