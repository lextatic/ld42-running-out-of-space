using DG.Tweening;
using UnityEngine;

public class Floaty : MonoBehaviour
{
	void Start ()
	{
		transform.DOMoveY(0.2f, .5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
	}
}
