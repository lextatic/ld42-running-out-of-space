using System.Collections;
using UnityEngine;

public class Floor : MonoBehaviour
{
	[SerializeField]
	private Rigidbody floorFallingTile;

	[SerializeField]
	private Transform floorTiltCollider;

	[SerializeField]
	private SimpleAudioEvent floorSounds;

	[SerializeField]
	private EmptyArea emptyArea;

	[SerializeField]
	private AudioSource audioSource;


	// Use this for initialization
	private void Start()
	{
		floorTiltCollider.Rotate(0, Random.Range(0, 4) * 90, 0);
		emptyArea.FloorFall += StartFallRoutine;
	}

	public void StartFallRoutine()
	{
		emptyArea.FloorFall -= StartFallRoutine;
		StartCoroutine(DelayedFall());
	}

	private IEnumerator DelayedFall()
	{
		yield return new WaitForSeconds(Random.Range(0f, 2f));
		floorFallingTile.isKinematic = false;
		floorSounds.Play(audioSource);
		yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
		floorTiltCollider.gameObject.SetActive(false);
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
