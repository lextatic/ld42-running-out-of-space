using UnityEngine;
using UnityEngine.SceneManagement;

public class SelfDestroy : MonoBehaviour
{
	[SerializeField]
	private float timeToDestroy = 3f;

	private void Update()
	{
		timeToDestroy -= Time.deltaTime;
		if(timeToDestroy <= 0)
		{
			Destroy(gameObject);
		}
	}
}
