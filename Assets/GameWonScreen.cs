using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonScreen : MonoBehaviour
{
	[SerializeField]
	CanvasGroup canvas;

	[SerializeField]
	string nextLevel;

	VictoryCondition victory;

	private void OnEnable()
	{
		victory = FindObjectOfType<VictoryCondition>();
		victory.OnVictory += HandlePlayerVictory;
	}

	private void OnDisable()
	{
		victory.OnVictory -= HandlePlayerVictory;
	}

	private void HandlePlayerVictory(bool obj)
	{
		canvas.DOFade(1f, 3f);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.anyKeyDown && canvas.alpha == 1)
		{
			SceneLoader.LoadScene(nextLevel);
		}
	}
}
