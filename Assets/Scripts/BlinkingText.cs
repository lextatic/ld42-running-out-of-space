using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BlinkingText : MonoBehaviour
{
	void Start ()
	{
		var blinkingText = GetComponent<Text>();
		DOTween.ToAlpha(() => blinkingText.color, x => blinkingText.color = x, 0, 0.7f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
	}
}
