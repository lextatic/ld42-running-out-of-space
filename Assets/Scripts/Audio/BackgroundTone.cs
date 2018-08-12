using System.Collections;
using UnityEngine;

public class BackgroundTone : MonoBehaviour
{
	[SerializeField]
	private SimpleAudioEvent backgroundTone;

	[SerializeField]
	private AudioSource audioSource;

	public void Start()
	{
		StartCoroutine(PlayTone(2f));
	}

	private IEnumerator PlayTone(float time)
	{
		backgroundTone.Play(audioSource);
		yield return new WaitForSeconds(time);
		time -= 0.01f;
		if (time < 1f) time = 1f;

		StartCoroutine(PlayTone(time));
	}
}
