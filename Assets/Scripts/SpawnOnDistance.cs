using UnityEngine;

public class SpawnOnDistance : PausableBehaviour {

	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private float spawnDistance = 1f;

	private Vector3 lastSpawnPosition;

	public override void Resume(bool startup)
	{
		base.Resume(startup);
		if (startup)
		{
			Spawn();
		}
	}
	
	void Update ()
	{
		if(Vector3.Distance(transform.position, lastSpawnPosition) >= spawnDistance)
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		lastSpawnPosition = transform.position;
		Instantiate(prefab, transform.position - Vector3.up * 0.4f, Quaternion.identity);
	}
}
