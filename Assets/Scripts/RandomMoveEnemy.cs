using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyMove))]
public class RandomMoveEnemy : MonoBehaviour
{
	[SerializeField]
	private EnemyMove enemyMove;

	[SerializeField]
	private float randomRadius = 5f;
	
	private float remainingDistanceThreshold = 1;

	private Vector3 currentTargetPosition;

	void Start ()
	{
		NewDestination();
	}

	private void Update()
	{
		if(enemyMove.RemainingDistance < remainingDistanceThreshold)
		{
			NewDestination();
		}
	}

	private void NewDestination()
	{
		Vector2 randonPosition = Random.insideUnitCircle * randomRadius;
		currentTargetPosition = transform.position + new Vector3(randonPosition.x, 0, randonPosition.y);

		enemyMove.SetDestination(currentTargetPosition);
	}
}
