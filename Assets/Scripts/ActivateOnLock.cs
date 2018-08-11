public class ActivateOnLock : ILockable
{
	public override void ActivateLock()
	{
		gameObject.SetActive(true);
	}
}
