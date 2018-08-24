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
	
	public Sprite bulletSprite;
	
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
		sprite.velocity = new Vector2(-30, 0);
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
		sprite.velocity = new Vector2(30, 0);
	}
	public void goUp(){
		isUp = true;
		isDown = false;
		isLeft = false;
		isRight = false;
		sprite.velocity = new Vector2(0, 30);
	}
	public void goDown(){
		isUp = false;
		isDown = true;
		isLeft = false;
		isRight = false;
		sprite.velocity = new Vector2(0, -30);
	}
	
	
	// Use this for initialization
	void Start () {
		isRight = false;
		isLeft = true;
		isDown = false;
		isUp = false;
		
		isFacingLeft = true;
		isFacingRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Check if player is on the zombie by a certain radius (zombieCheckRadius), from a rigidbody (sprite) for certain layers (whatIsZombie)
		onZombie = Physics2D.OverlapCircle(sprite.transform.position, zombieCheckRadius, whatIsZombie);
		if(onZombie){
			SceneManager.LoadScene ("Lose");
		}
		
	}
}
