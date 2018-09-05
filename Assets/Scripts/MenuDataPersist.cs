using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuDataPersist : MonoBehaviour {	
	
	public Text latestScoreText;
	public Text highScoreText;
	
	public int lastScore;
	public int highScore;
	
	public void updateCurrent(){
		lastScore = DataPersist.LoadScore();
		latestScoreText.text = "Latest Score: " + lastScore;
	}
	
	public void updateHighScore(){
		
		if(lastScore > DataPersist.LoadHighScore()){
			PlayerPrefs.SetInt("HighScore", lastScore);
		}
		highScore = DataPersist.LoadHighScore();
		highScoreText.text = "High Score: " + highScore;
		
	}
	
	
	void Start(){
		
		if(PlayerPrefs.HasKey("HighScore") == false){
			PlayerPrefs.SetInt("HighScore", 0);
		}
		
		
	}
	
	void Update(){
		
		updateCurrent();
		updateHighScore();
		
		
		
	}

}