using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SeekPlayerEnemy : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent navMeshAgent;

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
		if (navMeshAgent.remainingDistance < 1 || startSeekTime <= 0)
		{
			NewDestination();
		}
	}

	private void NewDestination()
	{
		navMeshAgent.SetDestination(player.position);
		startSeekTime = seekMaxCooldown;
	}
}
