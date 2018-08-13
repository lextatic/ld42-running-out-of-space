using UnityEngine;

public class LockObject : MonoBehaviour
{
	[SerializeField]
	private EmptyArea emptyArea;

	private void Start()
	{
		emptyArea.FloorFall += ActivateLock;
		gameObject.SetActive(false);
	}

	public void ActivateLock()
	{
		emptyArea.FloorFall -= ActivateLock;
		gameObject.SetActive(true);
	}
}
