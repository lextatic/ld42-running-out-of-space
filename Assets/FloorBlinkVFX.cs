using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBlinkVFX : MonoBehaviour
{

	float time = 0;

	Material myCopyMat;

	Color color = Color.white;

	public Color glowColor = new Color(1, 0.2f, 0.2f, 0.7f);

	float delay = 0;

	public void SetDelay(float delay)
	{
		this.delay = delay;
	}

	bool initialized = false;

	// Use this for initialization
	IEnumerator Start()
	{
		if (delay > 0)
		{
			yield return new WaitForSeconds(delay);
		}

		var renderer = this.GetComponentInChildren<Renderer>();

		myCopyMat = new Material(renderer.material);

		myCopyMat.globalIlluminationFlags |= MaterialGlobalIlluminationFlags.RealtimeEmissive;

		color = Color.white;

		myCopyMat.SetColor("_EmissionColor", color);

		renderer.material = myCopyMat;
		myCopyMat.EnableKeyword("_EMISSION");

		initialized = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (!initialized)
			return;

		time += Time.deltaTime*3;

		float sdt = (Mathf.Sin(time) + 1) / 2;
		color = Color.Lerp(color, glowColor * (1 - sdt) + Color.black * sdt, time % 1);

		myCopyMat.SetColor("_EmissionColor", color);
	}
}
