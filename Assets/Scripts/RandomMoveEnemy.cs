using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomMoveEnemy : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent navMeshAgent;

	[SerializeField]
	private float randomRadius = 5f;

	void Start ()
	{
		NewDestination();
	}

	private void Update()
	{
		if(navMeshAgent.remainingDistance < 1)
		{
			NewDestination();
		}
	}

	private void NewDestination()
	{
		Vector2 randonPosition = Random.insideUnitCircle * 5f;

		Vector3 targetDestination = transform.position + new Vector3(randonPosition.x, 0, randonPosition.y);

		navMeshAgent.SetDestination(targetDestination);
	}
}
