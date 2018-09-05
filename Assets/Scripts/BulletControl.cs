using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour {
	
	public  Rigidbody2D sprite;
	public Sprite bulletSprite;
	
	public bool pistolShotBullet;
	public bool pistolBulletPending;
	
	public bool rifleShotBullet;
	
	public bool shotShotBullet;
	public bool shotBulletPending;
	
	public GameObject bullet;
	
	public AudioSource audio;
	
	public GameObject borderX1;
	public GameObject borderX2;
	public GameObject borderY1;
	public GameObject borderY2;
	
	//This is the function that repsonds to the shoot button, it makes the boolean true to help succed to if statement in update
	public void shoot(){
		//audio.Play(0);
		if(GunsControl.isPistolActive == true){
			pistolShoot();
		}
		else if(GunsControl.isRifleActive == true){
			rifleShoot();
		}
		else if(GunsControl.isShotActive == true){
			shotShoot();
		}
		
	}
	
	public void pistolShoot(){
		pistolShotBullet = true;
	}
	
	public void rifleShoot(){
		
		rifleShotBullet = true;
		
	}
	
	public void shotShoot(){
		
		shotShotBullet = true;
		
	}
	
	
	void Start(){
		pistolShotBullet = false;
		pistolBulletPending = false;
		shotBulletPending  = false;
		bullet = new GameObject();
		
	}
	
	void Update(){
		//This part of the if statement checks if a the pistolShot() method is active and if there is any pistol bullets in the game. REMEBER: Pistols can only be shot after all other pistol bullets are gone
		if((pistolShotBullet == true && pistolBulletPending == false) && GunsControl.isPistolActive == true){
			
			
			
			//This part of the code creates the bullet object
			
			bullet = new GameObject();
			pistolBulletPending = true;
			bullet.AddComponent<SpriteRenderer>();
			bullet.AddComponent<Rigidbody2D>();
			bullet.AddComponent<BoxCollider2D>();
			bullet.transform.parent = GameObject.Find("Main Camera").transform;
			bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			bullet.layer = 9;
			bullet.transform.localScale = new Vector3(6,6,1);
			Vector2 tempColl = new Vector2(6,5);
			bullet.GetComponent<BoxCollider2D>().size = tempColl;
			Vector3 temp = new Vector3(sprite.position.x,sprite.position.y,0);
			bullet.transform.position = temp;
			bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
			audio.PlayOneShot(audio.clip);
			//This part determines which direction to shoot the bullet based on the sprite from PLayerController and what direction he is facing
			if(PlayerController.isRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(500,0);
				
			}
			else if(PlayerController.isLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-500,0);
				
			}
			else if(PlayerController.isDown == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-500);
			}
			else if(PlayerController.isUp == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,500);
			}
			else if(PlayerController.upRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(354,354);
			}
			else if(PlayerController.upLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-354,354);
			}
			else if(PlayerController.downLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-354,-354);
			}
			else if(PlayerController.downRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(354,-354);
			}
			
		}
		
		else if(rifleShotBullet == true && GunsControl.isRifleActive == true){
			
			
			bullet = new GameObject();
			
			
			bullet.AddComponent<SpriteRenderer>();
			bullet.AddComponent<Rigidbody2D>();
			bullet.AddComponent<BoxCollider2D>();
			bullet.transform.parent = GameObject.Find("Main Camera").transform;
			bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			bullet.layer = 9;
			bullet.transform.localScale = new Vector3(6,6,1);
			Vector2 tempColl = new Vector2(6,5);
			bullet.GetComponent<BoxCollider2D>().size = tempColl;
			Vector3 temp = new Vector3(sprite.position.x,sprite.position.y,0);
			bullet.transform.position = temp;
			bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
			GunsControl.rifleBullets--;
			rifleShotBullet = false;
			audio.PlayOneShot(audio.clip);
			//This part determines which direction to shoot the bullet based on the sprite from PLayerController and what direction he is facing
			if(PlayerController.isRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(500,0);
				
			}
			else if(PlayerController.isLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-500,0);
				
			}
			else if(PlayerController.isDown == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-500);
			}
			else if(PlayerController.isUp == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,500);
			}
			else if(PlayerController.upRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(354,354);
			}
			else if(PlayerController.upLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-354,354);
			}
			else if(PlayerController.downLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-354,-354);
			}
			else if(PlayerController.downRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(354,-354);
			}
		}
		//If the file accesor variables from gunscontrol says the shotgun is active, shoot shotgun bullets
		else if((shotShotBullet == true && shotBulletPending == false) && GunsControl.isShotActive == true){
			
			
			
			//This part of the code creates the bullet object
			bullet = new GameObject();
			shotBulletPending = true;
			bullet.AddComponent<SpriteRenderer>();
			bullet.AddComponent<Rigidbody2D>();
			bullet.AddComponent<BoxCollider2D>();
			bullet.transform.parent = GameObject.Find("Main Camera").transform;
			bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			bullet.layer = 9;
			GunsControl.shotBullets--;
			bullet.transform.localScale = new Vector3(12,12,2);
			Vector2 tempColl = new Vector2(6,5);
			bullet.GetComponent<BoxCollider2D>().size = tempColl;
			Vector3 temp = new Vector3(sprite.position.x,sprite.position.y,0);
			bullet.transform.position = temp;
			bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
			audio.PlayOneShot(audio.clip);
			//This part determines which direction to shoot the bullet based on the sprite from PLayerController and what direction he is facing
			if(PlayerController.isRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(500,0);
				
			}
			else if(PlayerController.isLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-500,0);
				
			}
			else if(PlayerController.isDown == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-500);
			}
			else if(PlayerController.isUp == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,500);
			}
			else if(PlayerController.upRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(354,354);
			}
			else if(PlayerController.upLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-354,354);
			}
			else if(PlayerController.downLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-354,-354);
			}
			else if(PlayerController.downRight == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(354,-354);
			}
		
			
		}
		
		//Delete pistol and shotgun buleets once they are passed the border and then allow them to be shot again
		if((pistolBulletPending == true || shotBulletPending == true) &&(bullet.GetComponent<Rigidbody2D>().position.x < borderX2.transform.position.x || bullet.GetComponent<Rigidbody2D>().position.x > borderX1.transform.position.x)){
				Destroy(bullet.GetComponent<Rigidbody2D>());
				Destroy(bullet.GetComponent<SpriteRenderer>());
				Destroy(bullet.GetComponent<BoxCollider2D>());
				pistolBulletPending = false;
				pistolShotBullet = false;
				shotBulletPending = false;
				shotShotBullet = false;
			
		}
		else if((pistolBulletPending  == true || shotBulletPending == true)&&(bullet.GetComponent<Rigidbody2D>().position.y < borderY2.transform.position.y || bullet.GetComponent<Rigidbody2D>().position.y > borderY1.transform.position.y)){
				Destroy(bullet.GetComponent<Rigidbody2D>());
				Destroy(bullet.GetComponent<SpriteRenderer>());
				Destroy(bullet.GetComponent<BoxCollider2D>());
				pistolBulletPending = false;
				pistolShotBullet = false;
				shotBulletPending = false;
				shotShotBullet = false;
				
		}
		
		
 
		
	}

}