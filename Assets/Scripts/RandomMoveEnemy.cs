using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyMove))]
public class RandomMoveEnemy : PausableBehaviour
{
	[SerializeField]
	private EnemyMove enemyMove;

	[SerializeField]
	private float randomRadius = 5f;
	
	private float remainingDistanceThreshold = 1;

	private Vector3 currentTargetPosition;
	
	override public void Resume(bool startup)
	{
		base.Resume(startup);
		if (startup)
		{
			NewDestination();
		}
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
