using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public Rigidbody2D sprite;
	public Button up;
	public Button down;
	public Button left;
	public Button right;
	
	public bool onZombie;
	public LayerMask whatIsZombie;
	public float zombieCheckRadius;
	
	//Boolean values to check what direction the main character is facing
	public static bool isRight;
	public static bool isLeft;
	
	public static bool isFacingRight;
	public static bool isFacingLeft;
	
	public static bool isDown;
	public static bool isUp;
	
	public static bool upRight;
	public static bool upLeft;
	public static bool downRight;
	public static bool downLeft;
	
	public Sprite bulletSprite;
	
	public GameObject borderX1;
	public GameObject borderX2;
	public GameObject borderY1;
	public GameObject borderY2;
	
	public void goLeft(){
		//coditional to make sure the character is facing the opposite direction, if passed, it goes in the opposite direction and flips the sprite to match direction
		if(isFacingRight == true && isFacingLeft == false){
			sprite.GetComponent<Transform>().localScale = new Vector3( sprite.GetComponent<Transform>().localScale.x * -1, sprite.GetComponent<Transform>().localScale.y, sprite.GetComponent<Transform>().localScale.z );
			isFacingLeft = true;
			isFacingRight = false;
		}
		isRight = false;
		isLeft = true;
		isUp = false;
		isDown = false;
		
		upRight = false;
		upLeft = false;
		downRight = false;
		downLeft = false;
		sprite.velocity = new Vector2(-30, 0);
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
	}
	public void goRight(){
		//coditional to make sure the character is facing the opposite direction, if passed, it goes in the opposite direction and flips the sprite to match direction
		if(isFacingLeft == true && isFacingRight == false){
			sprite.GetComponent<Transform>().localScale = new Vector3( sprite.GetComponent<Transform>().localScale.x * -1, sprite.GetComponent<Transform>().localScale.y, sprite.GetComponent<Transform>().localScale.z );	
			isFacingRight = true;
			isFacingLeft = false;
		}
		isRight = true;
		isLeft = false;
		isUp = false;
		isDown = false;
		
		upRight = false;
		upLeft = false;
		downRight = false;
		downLeft = false;
		sprite.velocity = new Vector2(30, 0);
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
	}
	public void goUp(){
		isUp = true;
		isDown = false;
		isLeft = false;
		isRight = false;
		
		upRight = false;
		upLeft = false;
		downRight = false;
		downLeft = false;
		sprite.velocity = new Vector2(0, 30);
		
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
	}
	public void goDown(){
		isUp = false;
		isDown = true;
		isLeft = false;
		isRight = false;
		
		upRight = false;
		upLeft = false;
		downRight = false;
		downLeft = false;
		sprite.velocity = new Vector2(0, -30);
		
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
	}
	
	public void goUpRight(){
		
		if(isFacingLeft == true && isFacingRight == false){
			sprite.GetComponent<Transform>().localScale = new Vector3( sprite.GetComponent<Transform>().localScale.x * -1, sprite.GetComponent<Transform>().localScale.y, sprite.GetComponent<Transform>().localScale.z );	
			isFacingRight = true;
			isFacingLeft = false;
		}
		isRight = false;
		isLeft = false;
		isUp = false;
		isDown = false;
		
		upRight = true;
		upLeft = false;
		downRight = false;
		downLeft = false;
		sprite.velocity = new Vector2(21.2f, 21.2f);
		
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
		
	}
	
	public void goUpLeft(){
		
		if(isFacingLeft == false && isFacingRight == true){
			sprite.GetComponent<Transform>().localScale = new Vector3( sprite.GetComponent<Transform>().localScale.x * -1, sprite.GetComponent<Transform>().localScale.y, sprite.GetComponent<Transform>().localScale.z );	
			isFacingRight = false;
			isFacingLeft = true;
		}
		isRight = false;
		isLeft = false;
		isUp = false;
		isDown = false;
		
		upRight = false;
		upLeft = true;
		downRight = false;
		downLeft = false;
		sprite.velocity = new Vector2(-21.2f, 21.2f);
		
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
		
	}
	
	public void goDownLeft(){
		
		if(isFacingLeft == false && isFacingRight == true){
			sprite.GetComponent<Transform>().localScale = new Vector3( sprite.GetComponent<Transform>().localScale.x * -1, sprite.GetComponent<Transform>().localScale.y, sprite.GetComponent<Transform>().localScale.z );	
			isFacingRight = false;
			isFacingLeft = true;
		}
		isRight = false;
		isLeft = false;
		isUp = false;
		isDown = false;
		
		upRight = false;
		upLeft = false;
		downRight = false;
		downLeft = true;
		sprite.velocity = new Vector2(-21.2f, -21.2f);
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
		
	}
	
	public void goDownRight(){
		
		if(isFacingLeft == true && isFacingRight == false){
			sprite.GetComponent<Transform>().localScale = new Vector3( sprite.GetComponent<Transform>().localScale.x * -1, sprite.GetComponent<Transform>().localScale.y, sprite.GetComponent<Transform>().localScale.z );	
			isFacingRight = true;
			isFacingLeft = false;
		}
		isRight = false;
		isLeft = false;
		isUp = false;
		isDown = false;
		
		upRight = false;
		upLeft = false;
		downRight = true;
		downLeft = false;
		sprite.velocity = new Vector2(21.2f, -21.2f);
		
		if(GunsControl.isSpeedPowerup == true){
			GunsControl.speedPowerupCounter++;
			sprite.velocity = new Vector2(3 * sprite.velocity.x, 3 * sprite.velocity.y);
		}
		
		
	}
	
	
	// Use this for initialization
	void Start () {
		isRight = false;
		isLeft = true;
		isDown = false;
		isUp = false;
		
		isFacingLeft = true;
		isFacingRight = false;
		
		upRight = false;
		upLeft = false;
		downRight = false;
		downLeft = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Check if player is on the zombie by a certain radius (zombieCheckRadius), from a rigidbody (sprite) for certain layers (whatIsZombie)
		onZombie = Physics2D.OverlapCircle(sprite.transform.position, zombieCheckRadius, whatIsZombie);
		
		if(onZombie){
			DataPersist.SaveScore();
			SceneManager.LoadScene ("Lose");
		}
		
		if(sprite.position.x > borderX1.transform.position.x || sprite.position.x < borderX2.transform.position.x){
			sprite.velocity = new Vector3(-1*sprite.velocity.x, sprite.velocity.y);
		}
		if(sprite.position.y > borderY1.transform.position.y || sprite.position.y < borderY2.transform.position.y){
			sprite.velocity = new Vector3(sprite.velocity.x, -1 * sprite.velocity.y);
		}
		
	}
}
