using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// WTF, destroy não dava trigger em OnTriggerExit?
			transform.position = new Vector3(0, -1000, 0);
			StartCoroutine(DelayedDestroy());
		}
	}

	private IEnumerator DelayedDestroy()
	{
		yield return null;
		Destroy(gameObject);
	}
}
