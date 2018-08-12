using UnityEngine;

public class PlayerSound : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(horizontal, 0, vertical);
		if(direction.magnitude > 1)
		{
			direction = direction.normalized;
		}

		if (direction.magnitude > 0)
		{
			if(!audioSource.isPlaying)
			{
				audioSource.Play();
			}

			float modifier = 0.04f;

			if(Physics.Raycast(transform.position, -transform.up, 1,  1 << LayerMask.NameToLayer("Effects")))
			{
				modifier = 0.02f;
			}

			audioSource.pitch = direction.magnitude * modifier;
		}
		else
		{
			audioSource.Stop();
		}
	}
}
