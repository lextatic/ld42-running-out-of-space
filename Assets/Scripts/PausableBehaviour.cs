using UnityEngine;

public abstract class PausableBehaviour : MonoBehaviour
{
	public virtual void Start()
	{
		StartupCountdown.Instance.OnGameStarted += Resume;
		VictoryCondition.Instance.OnVictory += Pause;
		Pause(false);
	}

	public virtual void Pause(bool victory)
	{
		//enabled = false;
	}

	public virtual void Resume(bool startup)
	{
		enabled = true;
	}

	public virtual void OnDestroy()
	{
		StartupCountdown.Instance.OnGameStarted -= Resume;
		VictoryCondition.Instance.OnVictory -= Pause;
	}
}
