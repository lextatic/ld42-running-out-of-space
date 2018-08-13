using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTouch : MonoBehaviour
{
	static public event System.Action PlayerDeath = delegate { };

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			PlayerDeath();
			//SceneManager.LoadScene(0);
		}
	}
}
