using UnityEngine;

public class SpawnOnDistance : MonoBehaviour {

	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private float spawnDistance = 1f;

	private Vector3 lastSpawnPosition;

	void Start ()
	{
		Spawn();
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
