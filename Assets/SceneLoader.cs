using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.anyKeyDown)
		{
			LoadScene("Level1");
		}
	}

	static public void LoadScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
