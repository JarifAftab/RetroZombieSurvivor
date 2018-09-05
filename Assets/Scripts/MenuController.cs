using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void launchGame(){
		SceneManager.LoadScene("play");
	}
	public void quitGame(){
		
		Application.Quit();
		
	}
	public void returnMenu(){
		SceneManager.LoadScene("mainMenu");
	}
}
