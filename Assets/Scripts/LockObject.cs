using UnityEngine;

public class LockObject : MonoBehaviour
{
	[SerializeField]
	private EmptyArea emptyArea;

	private void Start()
	{
		emptyArea.OnAreaEmptied += ActivateLock;
	}

	public void ActivateLock()
	{
		gameObject.SetActive(true);
	}
}
