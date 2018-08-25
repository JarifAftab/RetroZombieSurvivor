using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

	public Button exitButton;
	public Text text;

	
    public void PauseGame()
    {
        if(Time.timeScale == 1){
			Time.timeScale = 0;
			text.color = new Color (255,0,0,255);
			GetComponent<PlayerController>().enabled = false;
			GetComponent<ZombieController>().enabled = false;
			GetComponent<BulletControl>().enabled = false;
			
		}
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
			text.color = new Color(0,0,0,0);
			GetComponent<PlayerController>().enabled = true;
			GetComponent<ZombieController>().enabled = true;
			GetComponent<BulletControl>().enabled = true;
			
		}
    } 
	
	public void leaveButtonPause(){
		Time.timeScale = 1;
		SceneManager.LoadScene("planetSelect");
		
	}
}