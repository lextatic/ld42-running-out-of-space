using UnityEngine;

public class Teleporter : MonoBehaviour
{	
	[SerializeField]
	private Transform outPosition;

	public Vector3 OutPosition
	{
		get { return outPosition.position; }
	}

	private void OnTriggerEnter(Collider other)
	{
		other.transform.position = OutPosition;

		var randomMoveEnemy = other.GetComponent<RandomMoveEnemy>();
		if(randomMoveEnemy != null)
		{
			randomMoveEnemy.SetSecondPath();
		}
	}
}
