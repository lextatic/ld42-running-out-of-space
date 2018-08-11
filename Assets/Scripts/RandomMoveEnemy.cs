using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomMoveEnemy : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent navMeshAgent;

	[SerializeField]
	private float randomRadius = 5f;

	[SerializeField]
	private Teleporter[] teleporters;

	private NavMeshPath cachedTeleportPath2;

	[SerializeField]
	private Transform debugObject;

	private float remainingDistanceThreshold = 1;

	void Start ()
	{
		NewDestination();
	}

	private void Update()
	{
		if(navMeshAgent.remainingDistance < remainingDistanceThreshold)
		{
			NewDestination();
		}
	}

	private void NewDestination()
	{
		Vector2 randonPosition = Random.insideUnitCircle * randomRadius;
		Vector3 targetDestination = transform.position + new Vector3(randonPosition.x, 0, randonPosition.y);
		debugObject.position = targetDestination;
		
		var bestPath = new NavMeshPath();
		navMeshAgent.CalculatePath(targetDestination, bestPath);
		var bestPathLengh = CalculatePathDistance(bestPath);
		remainingDistanceThreshold = 1;

		foreach (Teleporter teleporter in teleporters)
		{
			var teleporterPath1 = new NavMeshPath();
			navMeshAgent.CalculatePath(teleporter.transform.position, teleporterPath1);
			var path1Lengh = CalculatePathDistance(teleporterPath1);

			var teleporterPath2 = new NavMeshPath();
			NavMesh.CalculatePath(teleporter.OutPosition, targetDestination, navMeshAgent.areaMask, teleporterPath2);
			var path2Lengh = CalculatePathDistance(teleporterPath2);

			if (path1Lengh + path2Lengh < bestPathLengh)
			{
				bestPathLengh = path1Lengh + path2Lengh;
				bestPath = teleporterPath1;
				cachedTeleportPath2 = teleporterPath2;
				remainingDistanceThreshold = 0;
			}
		}

		navMeshAgent.SetPath(bestPath);
	}

	private float CalculatePathDistance(NavMeshPath navMeshPath)
	{
		float distance = 0;
		var corners = navMeshPath.corners;
		for (int i = 0; i < corners.Length - 1; i++)
		{
			distance += Vector3.Distance(corners[i], corners[i + 1]);
		}
		return distance;
	}

	public void SetSecondPath()
	{
		remainingDistanceThreshold = 1;
		navMeshAgent.SetPath(cachedTeleportPath2);
	}
}
