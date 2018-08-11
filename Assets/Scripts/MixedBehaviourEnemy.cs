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

		// Preguiça de refazer o Inspector todo
		DrawDefaultInspector();

		//float minVal = myTarget.minMaxSeekCooldown;
		//float maxVal = myTarget.maxMaxSeekCooldown;
		//EditorGUI.BeginChangeCheck();
		EditorGUILayout.MinMaxSlider($"Seek Max Cooldown ({myTarget.minMaxSeekCooldown:0.0}|{myTarget.maxMaxSeekCooldown:0.0})", ref myTarget.minMaxSeekCooldown, ref myTarget.maxMaxSeekCooldown, 1, 10);
		//if (EditorGUI.EndChangeCheck())
		//{
		//	myTarget.minMaxSeekCooldown = minVal;
		//	myTarget.maxMaxSeekCooldown = maxVal;
		//}
		
		//minVal = myTarget.minRandomRadius;
		//maxVal = myTarget.maxRandomRadius;
		//EditorGUI.BeginChangeCheck();
		EditorGUILayout.MinMaxSlider($"Random Radius ({myTarget.minRandomRadius:0.0}|{myTarget.maxRandomRadius:0.0})", ref myTarget.minRandomRadius, ref myTarget.maxRandomRadius, 1, 20);
		//if (EditorGUI.EndChangeCheck())
		//{
		//	myTarget.minRandomRadius = minVal;
		//	myTarget.maxRandomRadius = maxVal;
		//}
	}
}
#endif

[RequireComponent(typeof(NavMeshAgent))]
public class MixedBehaviourEnemy : MonoBehaviour
{
	[SerializeField]
	private EnemyMove enemyMove;

	[SerializeField]
	[Range(0, 1)]
	private float seekPlayerChance = 0.5f;

	[SerializeField]
	private Transform player;

	public float minMaxSeekCooldown;
	public float maxMaxSeekCooldown;

	public float minRandomRadius;
	public float maxRandomRadius;

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
		if (Random.Range(0f, 1f) < seekPlayerChance)
		{
			enemyMove.SetDestination(player.position);
		}
		else
		{
			Vector2 randonPosition = Random.insideUnitCircle;
			Vector3 targetDestination = transform.position + (new Vector3(randonPosition.x, 0, randonPosition.y) * (minRandomRadius + Random.Range(0, maxRandomRadius - minRandomRadius)));
			enemyMove.SetDestination(targetDestination);
		}

		startSeekTime = Random.Range(minMaxSeekCooldown, maxMaxSeekCooldown);
	}
}
