using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour
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

		// Se for cair não aceita o move, assim podemos fazer buracos se quiser
		if (Physics.Raycast(transform.position + transform.forward * 0.3f, -transform.up, 1f))
		{
			characterController.SimpleMove(direction * velocity);
		}
	}
}
