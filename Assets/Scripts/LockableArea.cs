using UnityEngine;

public class LockableArea : MonoBehaviour
{
	private int objectsInsideCount = 0;

	[SerializeField]
	private ILockable[] lockObjectsList;

	private void OnTriggerEnter(Collider other)
	{
		objectsInsideCount++;
	}

	private void OnTriggerExit(Collider other)
	{
		objectsInsideCount--;
		if(objectsInsideCount == 0)
		{
			foreach(ILockable @lock in lockObjectsList)
			{
				@lock.ActivateLock();
			}
			Destroy(gameObject);
		}
	}
}
