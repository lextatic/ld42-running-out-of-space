using System.Collections;
using UnityEngine;

public class Floor : MonoBehaviour
{
	[SerializeField]
	private Rigidbody floorFallingTile;

	[SerializeField]
	private Transform floorTiltCollider;

	[SerializeField]
	private EmptyArea emptyArea;
	
	// Use this for initialization
	private void Start ()
	{
		floorTiltCollider.Rotate(0, Random.Range(0, 4) * 90, 0);
		emptyArea.OnAreaEmptied += ActivateLock;
	}

	public void ActivateLock()
	{
		StartCoroutine(DelayedFall());
	}

	private IEnumerator DelayedFall()
	{
		yield return new WaitForSeconds(Random.Range(0f, 2f));
		floorFallingTile.isKinematic = false;
		yield return new WaitForSeconds(Random.Range(0f, 0.1f));
		floorTiltCollider.gameObject.SetActive(false);
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
