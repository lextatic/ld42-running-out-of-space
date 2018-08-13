using UnityEngine;

public class PlayerAnimator : PausableBehaviour
{
	[SerializeField]
	private Transform handler;

	[SerializeField]
	private Transform[] wheels;

	private Vector3 lastDirection;

	// Update is called once per frame
	void LateUpdate ()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(horizontal, 0, vertical);

		foreach (var wheel in wheels)
		{
			wheel.Rotate(-720 * direction.magnitude * Time.deltaTime, 0, 0);
		}

		var handleValue = Vector3.Cross(transform.forward, lastDirection).y;

		handler.localRotation = Quaternion.Euler(25f, Mathf.Max(Mathf.Min(-360f * handleValue * 30, 30f), -30), 0);

		lastDirection = transform.forward;
	}
}
