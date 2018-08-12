using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : PausableBehaviour
{
	[SerializeField]
	private CharacterController characterController;

	[SerializeField]
	private float velocity = 5;
	
	void Update ()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(horizontal, 0, vertical);

		// Isso faz o personagem ficar sembre virado nos eixos pos o valor dos axis vai decrementando, deixei porque achei legal
		if (direction.magnitude > 0)
		{
			transform.forward = direction;
		}

		characterController.SimpleMove(direction * velocity);
	}
}
