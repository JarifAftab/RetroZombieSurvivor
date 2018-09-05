using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GunsControl : MonoBehaviour {
	

	
	public Rigidbody2D player; //Player variable to refernece to if bullet is ever on player
	
	public GameObject pistol;//Gameobejcts for the sprites of the weapons
	public GameObject rifle;
		public static int rifleBullets;//The number of bullets
		public Text rifleBulletText;//The ammo count
	
	public GameObject shotgun;
		public static int shotBullets;
		public Text shotBulletText;
	
	public static bool isPistolActive;//these variables are accesed by bullet control to check what kind of bullet is fired
	public static bool isRifleActive;
	public static bool isShotActive;
	
	public static bool isSpeedPowerup;//boolan for other scipts like PlauerController to change the spped only if the powerup is active
	public static int speedPowerupCounter;//after 20 moves, based on PLayer Controller script, the powerup will be deactivited
		public Text speedUp;
	
	public GameObject powerup;//THe powerup game object
	public static bool powerupActive;//THis varbibale makes sure that a powerup spawns once the active one is done aka. a wepaons ammo has been used up
	public bool powerupDestroyed;//A bug fix to make sure that once hitting a powerup, you cannot go back to it once the wepaon has been used up
	
	//player collision
	public LayerMask whatIsPlayer;
	public bool onPlayer;
	public float pRadius;
	
	
	
	public void giveDrop(){
		
		if(powerupActive == false){
			//Creates the actual powerup
			powerup.AddComponent<SpriteRenderer>();
			powerup.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y,1);
			powerup.GetComponent<SpriteRenderer>().sprite = pistol.GetComponent<SpriteRenderer>().sprite;
			powerup.transform.position = new Vector3(Random.Range(10,475), Random.Range(-15,374), 1); //randomzies the position
			onPlayer = Physics2D.OverlapCircle(powerup.transform.position, pRadius, whatIsPlayer);//?
			powerupActive = true;//Tells game the powerup is active and a nother one cannot be spawned
			powerupDestroyed = false;//Stops bug from constantly picking random wepaon
			
		}
		else if(powerupActive == true){ //only when a powerup has been activited should the game check if a player has touched it
			
			onPlayer = Physics2D.OverlapCircle(powerup.transform.position, pRadius, whatIsPlayer);
			if(onPlayer && powerupDestroyed == false){//if the player has touched the powerup, give a random wepaons
				Destroy(powerup.GetComponent<SpriteRenderer>());//
				powerupDestroyed = true;
				double num = Random.Range(0,100);
				if(num >=0 && num < 33){
					//If it is a rifle, make sure that all the other weapons are diasabled and show the rifle bullet count
					pistol.GetComponent<SpriteRenderer>().enabled = false;
					rifle.GetComponent<SpriteRenderer>().enabled = true;
					shotgun.GetComponent<SpriteRenderer>().enabled = false;
					rifleBullets = 30;
					
				}
				else if(num >= 33 && num < 66){
					
					pistol.GetComponent<SpriteRenderer>().enabled = false;
					rifle.GetComponent<SpriteRenderer>().enabled = false;
					shotgun.GetComponent<SpriteRenderer>().enabled = true;
					shotBullets = 5;
					
				}
				else if(num >= 66 && num <= 100){
					isSpeedPowerup = true;
				}
				
			}
			
		}
		
	}
	
	void Start(){
		powerup = new GameObject();
		rifle.GetComponent<SpriteRenderer>().enabled = false;
		shotgun.GetComponent<SpriteRenderer>().enabled = false;
		powerupActive = false;
		rifleBulletText.text = "";
		shotBulletText.text = "";
		speedUp.text = "";
		isSpeedPowerup = false;
		speedPowerupCounter = 0;
		
	}
	void Update(){
		
		giveDrop();
		if(pistol.GetComponent<SpriteRenderer>().enabled == true){
			//When the pistol is active make sure the file accesor variables for the weapons are suited so that it only shoots pistol ammo
			isPistolActive = true;
			isRifleActive = false;
			isShotActive = false;
		}	
		else if(rifle.GetComponent<SpriteRenderer>().enabled == true){
			
			isPistolActive = false;
			isRifleActive = true;
			isShotActive = false;
			rifleBulletText . text = "X" + rifleBullets;
			shotBulletText.text = "";
			if(rifleBullets <= 0){ //Once rifle bullets have reached 0, bring back pistol and disable the othher guns and allow powerups to be spawned again
				isPistolActive = true;
				isRifleActive = false;
				isShotActive = false;
				rifle.GetComponent<SpriteRenderer>().enabled = false;
				pistol.GetComponent<SpriteRenderer>().enabled = true;
				powerupActive = false;
				rifleBulletText.text = "";
				
			}
			
		}
		else if(shotgun.GetComponent<SpriteRenderer>().enabled == true){
			
			isPistolActive = false;
			isRifleActive = false;
			isShotActive = true;
			shotBulletText . text = "X" + shotBullets;
			rifleBulletText . text = "";
			if(shotBullets <= 0){
				isPistolActive = true;
				isRifleActive = false;
				isShotActive = false;
				rifle.GetComponent<SpriteRenderer>().enabled = false;
				shotgun.GetComponent<SpriteRenderer>().enabled = false;
				pistol.GetComponent<SpriteRenderer>().enabled = true;
				powerupActive = false;
				shotBulletText.text = "";
				
			}
			
		}
		
		if(isSpeedPowerup == true){ // A sperate if statement because the pistol statement is always active so it would never reach it if it were an else if
			print(speedPowerupCounter);			speedUp.text = "Speed Active";
			if(speedPowerupCounter == 20){
				speedPowerupCounter = 0;
				isSpeedPowerup = false;
				powerupActive = false;
				speedUp.text = "";
			}
		}
		
	}
}