using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	private GameObject MainMenuPanel;

	[SerializeField]
	private GameObject SelectDificultyPanel;

	[SerializeField]
	private Image ArrowUp;
	[SerializeField]
	private Image ArrowDown;
	[SerializeField]
	private GameObject DificultyTexts;
	[SerializeField]
	private Text BlinkingUnityText;
	[SerializeField]
	private TMP_Text BlinkingTextMesh;

	// 0 Main Menu, 1 Select Dificulty
	int panelIndex = 0;

	// 0 Stroll, 1 Medium, 2 Panic
	int selectedDificulty = 1;

	[SerializeField]
	private string[] Levels;

	private void Start()
	{
		SelectDificultyPanel.SetActive(false);
		MainMenuPanel.SetActive(true);

		DOTween.ToAlpha(() => BlinkingUnityText.color, x => BlinkingUnityText.color = x, 0, 0.7f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
		DOTween.ToAlpha(() => BlinkingTextMesh.color, x => BlinkingTextMesh.color = x, 0, 0.7f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
		ArrowUp.transform.DOLocalMoveY(ArrowUp.transform.localPosition.y + 5, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
		ArrowDown.transform.DOLocalMoveY(ArrowDown.transform.localPosition.y - 5, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
	}

	// Update is called once per frame
	void Update()
	{
		if(panelIndex == 0)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
				return;
			}

			if (Input.anyKeyDown)
			{
				ChangePanel(1);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ChangePanel(0);
				return;
			}

			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				IncreaseDificulty();
				return;
			}

			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				DecreaseDificulty();
				return;
			}

			if (Input.anyKeyDown)
			{
				LoadScene(Levels[selectedDificulty]);
			}
		}
	}

	public void IncreaseDificulty()
	{
		if(selectedDificulty < 2)
		{
			selectedDificulty++;
			
			DificultyTexts.transform.DOLocalMoveY(45 - selectedDificulty * 40, 1);
		}

		ArrowDown.enabled = true;

		if (selectedDificulty == 2)
		{
			ArrowUp.enabled = false;
		}
	}

	public void DecreaseDificulty()
	{
		if (selectedDificulty > 0)
		{
			selectedDificulty--;

			DificultyTexts.transform.DOLocalMoveY(45 - selectedDificulty * 40, 1);
		}

		ArrowUp.enabled = true;

		if (selectedDificulty == 0)
		{
			ArrowDown.enabled = false;
		}
	}

	public void ChangePanel(int panel)
	{
		panelIndex = panel;

		MainMenuPanel.SetActive(panel == 0);
		SelectDificultyPanel.SetActive(panel == 1);
	}

	static public void LoadScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
