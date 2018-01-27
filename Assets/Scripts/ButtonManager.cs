using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public GameObject TitleScreen;
	public GameObject IntroScreen;

	public void introGameBtn (string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}
	public void startGameBtn()
	{
		TitleScreen.SetActive(false);
		IntroScreen.SetActive(true);
	}

}
