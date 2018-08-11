using UnityEngine;

public class SelfDestroy : PausableBehaviour
{
	[SerializeField]
	private float timeToDestroy = 3f;

	public override void Start()
	{
		base.Start();
		Resume(true);
	}

	private void Update()
	{
		timeToDestroy -= Time.deltaTime;
		if(timeToDestroy <= 0)
		{
			Destroy(gameObject);
		}
	}
}
