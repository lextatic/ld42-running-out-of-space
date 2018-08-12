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
			StartCoroutine(PlayGhostSound(0));
		}
	}

	public override void Pause(bool victory)
	{
		base.Pause(victory);

		StopAllCoroutines();
	}

	private IEnumerator PlayGhostSound(float time)
	{
		yield return new WaitForSeconds(time);
		ghostSounds.Play(audioSource);
		StartCoroutine(PlayGhostSound(Random.Range(randomTime.minValue, randomTime.maxValue)));
	}
}
