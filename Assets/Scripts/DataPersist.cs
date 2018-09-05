using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataPersist : MonoBehaviour {	
	
	public static void SaveScore(){

		PlayerPrefs.SetInt("Score", ZombieController.zombieKillCount);

	}
	public static int LoadScore(){
		
		return PlayerPrefs.GetInt("Score");

	}
	
	public static void SaveHighScore(){
		
		PlayerPrefs.SetInt("HighScore", ZombieController.zombieKillCount);
		
	}
	
	public static int LoadHighScore(){
		return PlayerPrefs.GetInt("HighScore");
	}
	
}