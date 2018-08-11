using UnityEngine;

public class LockObject : MonoBehaviour
{
	[SerializeField]
	private EmptyArea emptyArea;

	private void Start()
	{
		emptyArea.OnAreaEmptied += ActivateLock;
		gameObject.SetActive(false);
	}

	public void ActivateLock()
	{
		gameObject.SetActive(true);
	}
}
