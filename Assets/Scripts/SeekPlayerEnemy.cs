using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyMove))]
public class SeekPlayerEnemy : MonoBehaviour
{
	[SerializeField]
	private EnemyMove enemyMove;

	[SerializeField]
	private Transform player;

	[SerializeField]
	private float seekMaxCooldown = 5f;

	private float startSeekTime;

	void Start ()
	{
		NewDestination();
	}

	private void Update()
	{
		startSeekTime -= Time.deltaTime;
		if (enemyMove.RemainingDistance < 1 || startSeekTime <= 0)
		{
			NewDestination();
		}
	}

	private void NewDestination()
	{
		enemyMove.SetDestination(player.position);
		startSeekTime = seekMaxCooldown;
	}
}
