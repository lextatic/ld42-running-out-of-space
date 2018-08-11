using System;
using System.Collections;
using UnityEngine;

public class StartupCountdown : MonoBehaviour
{
	public Action<bool> OnGameStarted;

	public static StartupCountdown Instance;

	private void Awake()
	{
		Instance = this;
		StartCoroutine(Countdown());
	}

	private IEnumerator Countdown()
	{
		Debug.Log("3");
		yield return new WaitForSeconds(1f);
		Debug.Log("2");
		yield return new WaitForSeconds(1f);
		Debug.Log("1");
		yield return new WaitForSeconds(1f);
		Debug.Log("Go!");
		OnGameStarted?.Invoke(true);
	}
}
