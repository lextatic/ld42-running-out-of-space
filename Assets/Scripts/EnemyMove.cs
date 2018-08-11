using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : PausableBehaviour
{
	[SerializeField]
	private NavMeshAgent navMeshAgent;

	private Teleporter[] teleporters;

	private NavMeshPath _cachedTeleportPath;
	private float _cachedTeleportPathDistance;
	private bool usingTeleporterPath = false;

	public float RemainingDistance
	{
		get
		{
			if(usingTeleporterPath)
			{
				return navMeshAgent.remainingDistance + _cachedTeleportPathDistance;
			}
			else
			{
				return navMeshAgent.remainingDistance;
			}
		}
	}

#if UNITY_EDITOR
	[SerializeField]
	private GameObject debugObjectPrefab;
	private Transform debugObject;
#endif

	public override void Start()
	{
		base.Start();

#if UNITY_EDITOR
		debugObject = Instantiate(debugObjectPrefab, transform.position, transform.rotation).transform;
		debugObject.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material; // Só pra atualizar a cor por enquanto
#endif
		teleporters = FindObjectsOfType<Teleporter>();

		for(int i = 0; i < teleporters.Length; i++)
		{
			teleporters[i].OnTeleportEntered += OnTeleporterEntered;
		}
	}

	override public void Pause(bool victory)
	{
		base.Pause(victory);
		navMeshAgent.isStopped = true;
	}

	override public void Resume(bool startup)
	{
		base.Resume(startup);
		navMeshAgent.isStopped = false;
	}

	public void SetDestination(Vector3 destination)
	{
#if UNITY_EDITOR
		debugObject.position = destination;
#endif

		var bestPath = new NavMeshPath();
		navMeshAgent.CalculatePath(destination, bestPath);
		var bestPathLengh = CalculatePathDistance(bestPath);
		usingTeleporterPath = false;


		foreach (Teleporter teleporter in teleporters)
		{
			var teleporterPath1 = new NavMeshPath();
			navMeshAgent.CalculatePath(teleporter.transform.position, teleporterPath1);
			var path1Lengh = CalculatePathDistance(teleporterPath1);

			var teleporterPath2 = new NavMeshPath();
			NavMesh.CalculatePath(teleporter.OutPosition, destination, navMeshAgent.areaMask, teleporterPath2);
			var path2Lengh = CalculatePathDistance(teleporterPath2);

			if (path1Lengh + path2Lengh < bestPathLengh)
			{
				bestPathLengh = path1Lengh + path2Lengh;
				bestPath = teleporterPath1;
				_cachedTeleportPath = teleporterPath2;
				_cachedTeleportPathDistance = path2Lengh;
				usingTeleporterPath = true;
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

	private void OnTeleporterEntered(Collider other)
	{
		if (other.gameObject == gameObject)
		{
			if (usingTeleporterPath)
			{
				navMeshAgent.ResetPath();
				navMeshAgent.SetPath(_cachedTeleportPath);
				usingTeleporterPath = false;
			}
			else
			{
				Debug.Log("Shoudn't be called ever");
			}
		}
	}
}
