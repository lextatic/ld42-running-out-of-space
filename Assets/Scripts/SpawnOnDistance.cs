using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDistance : MonoBehaviour {

	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private float spawnDistance = 1f;

	private Vector3 lastSpawnPosition;

	// Use this for initialization
	void Start ()
	{
		Spawn();
	}
	
	// Update is called once per frame
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
