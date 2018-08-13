using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFade : MonoBehaviour
{
	[SerializeField]
	CanvasGroup canvas;

	[SerializeField]
	float targetAlpha;

	[SerializeField]
	float delay;

	[SerializeField]
	float time;

	void OnEnable()
	{
		StartCoroutine(DoTween());
	}



	// Use this for initialization
	IEnumerator DoTween()
	{
		yield return new WaitForSeconds(delay);
		canvas.DOFade(targetAlpha, time);
	}
}
