
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour {
	
	public Rigidbody2D sprite; 
	public Sprite zombieSprite;
	public GameObject zombieTemplate;
	
	//Variables to check if the zombie is on the bullet
	public bool onBullet;
	public LayerMask whatIsBullet;
	public float bulletCheckRadius;
	
	//List of all the zombies that have been spawned, used so each can be mainpulated seperately
	public List<GameObject> zombieList  = new List<GameObject>();
	public List<int>zombieEraseList = new List<int>(); //List of zombies to be erased
	
	//ZOmbie stastics that get upped everytime 8 zombies are killed
	public int zombieCount=0;
	public static int zombieKillCount = 0;
	public int zombieSpawnCount = 2;
	public float zombieSpeed = 0.2f;
	
	//Text that updates the Player's score
	public Text text;
	

	public int getScore(){
		return zombieKillCount;
	}
	
	//FUnction to lay the framework of the zombie
	public void spawnZombie(){
		GameObject zombie = Instantiate(zombieTemplate);
		zombie.transform.parent = GameObject.Find("Main Camera").transform;
		zombie.transform.position = new Vector3(Random.Range(-207,212), Random.Range(-164,168), 1);
		zombie.AddComponent<SpriteRenderer>();
		zombie.AddComponent<Rigidbody2D>();
		zombie.GetComponent<Rigidbody2D>().isKinematic = true;
		zombie.AddComponent<BoxCollider2D>();
		zombie.GetComponent<BoxCollider2D>().size = new Vector2(5,5);
		zombie.layer = 8;
		zombie.transform.localScale = new Vector3(sprite.transform.localScale.x,sprite.transform.localScale.y,1);
		zombie.GetComponent<SpriteRenderer>().sprite = zombieSprite;
		zombieList.Add(zombie);//Adds zombie to an array list instead of a public varibale so multiple zombies can be manipulated
		zombieCount++;
		

	}
	//THis function checks all the active zombies
	public void checkDeadZombies(){
		//This variableness goes through all the zombies in the array list and makes them chase the player
		for(int i = 0; i < zombieList.Count; i++){
			onBullet = Physics2D.OverlapCircle(zombieList[i].transform.position, bulletCheckRadius, whatIsBullet); //checks collision between zombies and pullets
			zombieList[i].transform.position = Vector3.MoveTowards(zombieList[i].transform.position, sprite.position, zombieSpeed);//chases player
			//If there is a collision between bullets and zombies it deletes it from the array list
			if(onBullet){
				//zombieEraseList.Add(i);
				Destroy(zombieList[i]);//Come from the foreach loop
				zombieList.Remove(zombieList[i]);//Come from foreach loop
				zombieCount--;
				zombieKillCount++;
				
			}
			
		
		}

	}
	
	public void updateSpawnSpeed(){
		if((zombieKillCount % 8 == 0)){
			
				zombieSpawnCount += 2;
				zombieSpeed += 0.1f;
			
			}
	}
	
	// Use this for initialization
	void Start () {
		zombieTemplate = new GameObject();
		spawnZombie();
		spawnZombie();
		zombieKillCount = 0;
		
		
	}
	
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + zombieKillCount;
		checkDeadZombies();
		if(zombieCount == 0){
			//Adds difficulty curve
			updateSpawnSpeed();
			for(int i = 0; i < zombieSpawnCount; i++){
				spawnZombie();
			}
		}
		
	}
}
