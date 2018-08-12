using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyMove))]
public class SeekPlayerEnemy : PausableBehaviour
{
	[SerializeField]
	private EnemyMove enemyMove;

	private Transform player;

	[SerializeField]
	private float seekMaxCooldown = 5f;

	private float startSeekTime;

	override public void Resume(bool startup)
	{
		base.Resume(startup);
		if (startup)
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
			NewDestination();
		}
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
