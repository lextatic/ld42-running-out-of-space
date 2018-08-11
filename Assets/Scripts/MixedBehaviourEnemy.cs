using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(MixedBehaviourEnemy))]
public class MixedBehaviourEnemyEditor : Editor
{
	public override void OnInspectorGUI()
	{
		MixedBehaviourEnemy myTarget = (MixedBehaviourEnemy)target;

		DrawDefaultInspector();

		float minVal = myTarget.seekMaxCooldown.min;
		float maxVal = myTarget.seekMaxCooldown.max;
		EditorGUI.BeginChangeCheck();
		EditorGUILayout.MinMaxSlider($"Seek Max Cooldown ({minVal:0.0}-{maxVal:0.0})", ref minVal, ref maxVal, 1, 5);
		if (EditorGUI.EndChangeCheck())
		{
			myTarget.seekMaxCooldown = new RangeAttribute(minVal, maxVal);
		}
		
		minVal = myTarget.randomRadius.min;
		maxVal = myTarget.randomRadius.max;
		EditorGUI.BeginChangeCheck();
		EditorGUILayout.MinMaxSlider($"Random Radius ({minVal:0.0}-{maxVal:0.0})", ref minVal, ref maxVal, 1, 20);
		if (EditorGUI.EndChangeCheck())
		{
			myTarget.randomRadius = new RangeAttribute(minVal, maxVal);
		}
	}
}
#endif

[RequireComponent(typeof(NavMeshAgent))]
public class MixedBehaviourEnemy : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent navMeshAgent;

	[SerializeField]
	[Range(0, 1)]
	private float seekPlayerChance = 0.5f;

	[SerializeField]
	private Transform player;

	public RangeAttribute seekMaxCooldown = new RangeAttribute(1, 5);
	
	public RangeAttribute randomRadius = new RangeAttribute(1, 20);

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
		if (Random.Range(0f, 1f) < seekPlayerChance)
		{
			navMeshAgent.SetDestination(player.position);
		}
		else
		{
			Vector2 randonPosition = Random.insideUnitCircle;
			Vector3 targetDestination = transform.position + (new Vector3(randonPosition.x, 0, randonPosition.y) * (randomRadius.min + Random.Range(randomRadius.max - randomRadius.min, randomRadius.max)));
			navMeshAgent.SetDestination(targetDestination);
		}

		startSeekTime = Random.Range(seekMaxCooldown.min, seekMaxCooldown.max);
	}
}
