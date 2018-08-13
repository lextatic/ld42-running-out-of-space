using UnityEngine;

public class LockObject : MonoBehaviour
{
	[SerializeField]
	private EmptyArea emptyArea;

	private void Start()
	{
		emptyArea.GhostsCleared += ActivateLock;
		gameObject.SetActive(false);
	}

	public void ActivateLock()
	{
		gameObject.SetActive(true);
	}
}
