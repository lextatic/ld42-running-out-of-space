using UnityEngine;

public class PlayerSound : PausableBehaviour
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

			float pitchModifier = 0.8f;
			float volumeModifier = 0.05f;

			if (Physics.Raycast(transform.position, -transform.up, 1,  1 << LayerMask.NameToLayer("Effects")))
			{
				pitchModifier = 0.6f;
				volumeModifier = 0.03f;
			}

			audioSource.pitch = 0.6f + direction.magnitude * pitchModifier - 0.6f;
			audioSource.volume = volumeModifier;
		}
		else
		{
			audioSource.Stop();
		}
	}
}
