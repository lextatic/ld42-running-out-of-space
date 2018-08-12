using System.Collections;
using UnityEngine;

public class EnemySound : PausableBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private SimpleAudioEvent ghostSounds;

	[SerializeField]
	[MinMaxRange(2, 10)]
	private RangedFloat randomTime;

	public override void Resume(bool startup)
	{
		base.Resume(startup);

		if(startup)
		{
			StartCoroutine(PlayGhostSound());
		}
	}

	public override void Pause(bool victory)
	{
		base.Pause(victory);

		StopAllCoroutines();
	}

	private IEnumerator PlayGhostSound()
	{
		var waitTime = Random.Range(randomTime.minValue, randomTime.maxValue);
		yield return new WaitForSeconds(waitTime);
		ghostSounds.Play(audioSource);
		StartCoroutine(PlayGhostSound());
	}
}
