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
		yield return new WaitForSeconds(6f);
		
		OnGameStarted?.Invoke(true);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneLoader.LoadScene("MainMenu");
		}
	}
}
