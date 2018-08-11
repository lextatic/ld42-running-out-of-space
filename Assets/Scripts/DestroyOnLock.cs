using UnityEngine;

public class DestroyOnLock : ILockable
{
	public override void ActivateLock()
	{
		Destroy(gameObject);
	}
}
