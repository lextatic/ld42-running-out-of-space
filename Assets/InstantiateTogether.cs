using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTogether : MonoBehaviour
{

	[SerializeField]
	GameObject prefab;

	// Use this for initialization
	void Start()
	{
		Instantiate(prefab, this.transform.position, this.transform.rotation);
	}

}
