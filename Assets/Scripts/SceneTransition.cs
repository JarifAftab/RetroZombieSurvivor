using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
	
	public Animator transition;
	public string sceneName = "mainMenu";
	
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(LoadScene());
	}
	
	IEnumerator LoadScene(){
		
		
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(sceneName);
		
		
	}
}