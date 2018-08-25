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
	
	public GameObject bullet;
	
	//This is the function that repsonds to the shoot button, it makes the boolean true to help succed to if statement in update
	public void pistolShoot(){
		pistolShotBullet = true;
	}
	
	/*public void shootBullet(){
		
		
			GameObject bullet;
			bullet = new GameObject();
			bullet.AddComponent<SpriteRenderer>();
			bullet.AddComponent<Rigidbody2D>();
			bullet.AddComponent<BoxCollider2D>();
			bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			bullet.transform.localScale = new Vector3(6,6,1);
			Vector2 tempColl = new Vector2(1,1);
			bullet.GetComponent<BoxCollider2D>().size = tempColl;
			Vector3 temp = new Vector3(sprite.position.x,sprite.position.y,0);
			bullet.transform.position = temp;
			bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
			if(PlayerController.isRight == true && PlayerController.isLeft == false){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(230, bullet.GetComponent<Rigidbody2D>().velocity.y);
				
			}
			else if(PlayerController.isRight == false && PlayerController.isLeft == true){
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-230, bullet.GetComponent<Rigidbody2D>().velocity.y);
				
			}
			
		
		
		
	}*/
	
	void Start(){
		pistolShotBullet = false;
		pistolBulletPending = false;
		bullet = new GameObject();
	}
	
	void Update(){
		//This part of the if statement checks if a the pistolShot() method is active and if there is any pistol bullets in the game. REMEBER: Pistols can only be shot after all other pistol bullets are gone
		if(pistolShotBullet == true && pistolBulletPending == false){
			
			
			
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
		//
		if(pistolBulletPending == true &&(bullet.GetComponent<Rigidbody2D>().position.x < 20 || bullet.GetComponent<Rigidbody2D>().position.x > 465)){
				Destroy(bullet.GetComponent<Rigidbody2D>());
				Destroy(bullet.GetComponent<SpriteRenderer>());
				Destroy(bullet.GetComponent<BoxCollider2D>());
				pistolBulletPending = false;
				pistolShotBullet = false;
		}
		else if(pistolBulletPending == true &&(bullet.GetComponent<Rigidbody2D>().position.y < -4 || bullet.GetComponent<Rigidbody2D>().position.y > 356)){
				Destroy(bullet.GetComponent<Rigidbody2D>());
				Destroy(bullet.GetComponent<SpriteRenderer>());
				Destroy(bullet.GetComponent<BoxCollider2D>());
				pistolBulletPending = false;
				pistolShotBullet = false;
		}
		
 
		
	}

}