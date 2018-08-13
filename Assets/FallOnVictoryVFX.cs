using DG.Tweening;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(FallOnVictoryVFX))]
public class FallOnVictoryVFXEditor : Editor
{
	public override void OnInspectorGUI()
	{
		EditorGUI.BeginDisabledGroup(!Application.isPlaying);
		if (GUILayout.Button("Test Fall"))
		{
			(target as FallOnVictoryVFX).FallDown((target as FallOnVictoryVFX).transform, 0f, 0.5f);
		}
		EditorGUI.EndDisabledGroup();

		base.OnInspectorGUI();
	}
}
#endif

public class FallOnVictoryVFX : MonoBehaviour
{
	VictoryCondition victory;

	private void OnEnable()
	{
		victory = FindObjectOfType<VictoryCondition>();
		victory.OnVictory += HandleVictory;
	}

	private void OnDisable()
	{
		victory.OnVictory -= HandleVictory;
	}

	private void HandleVictory(bool obj)
	{
		FallDown(this.transform, 1.0f, 0.1f);
	}

	public void FallDown(Transform transform, float delay, float delayScale)
	{
		var playerPosition = GameObject.FindObjectOfType<CharacterMove>().transform.position;

		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			var childtransform = transform.GetChild(i);
			var distance = Vector3.Distance(playerPosition, childtransform.position);
			childtransform.DOLocalMoveY(childtransform.localPosition.y - 5, 0.5f).SetEase(Ease.InExpo).SetDelay(delay + distance * delayScale);
		}
	}
}
