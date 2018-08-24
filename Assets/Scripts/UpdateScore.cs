using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {
	public int score;
	public Text text;
	
	// Use this for initialization
	void Start () {
		score= 0;
		score = ZombieController.zombieKillCount;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		text.text = "Score: "+ score;
		
	}
}
