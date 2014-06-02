﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float gravitiScale = 5f;
	public float setGravityCooldown = 1f;
	public float jumpForce = 1000f;
	float gravityCooldown = 0f;
	float jumpCooldown = 0f;
	float setJumpCooldown = 0.5f;
	float changeColliderCooldown = 20f;
	float setColliderCooldown = 20f;

	BoxCollider2D boxCollider;
	Vector2 colliderSize;
	Vector2 colliderCenter;
	bool playerJump;

	public bool dead = false;
	

	// Use this for initialization
	void Start () 
	{
		playerJump = false;
		rigidbody2D.gravityScale = gravitiScale;
		boxCollider = gameObject.collider2D as BoxCollider2D;//GetComponent(BoxCollider2D);
		colliderSize = boxCollider.size;
		colliderCenter = boxCollider.center;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(transform.position.x <= 0)
		{
			transform.Translate(0.5f * Time.deltaTime,0,0);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(playerJump == false && rigidbody2D.gravityScale == gravitiScale)
			{
				rigidbody2D.AddForce(new Vector2(0,jumpForce));
				playerJump = true;
				jumpCooldown = Time.time + setJumpCooldown;
			}
			if(playerJump == false && rigidbody2D.gravityScale == -gravitiScale)
			{
				rigidbody2D.AddForce(new Vector2(0,-jumpForce));
				playerJump = true;
				jumpCooldown = Time.time + setJumpCooldown;
			}
		}
		if(Input.GetKeyDown (KeyCode.W) && Time.time > gravityCooldown)
		{
			if(rigidbody2D.gravityScale >= gravitiScale)
			{
				rigidbody2D.gravityScale = -gravitiScale;
				gravityCooldown =  Time.time + setGravityCooldown;
				transform.localScale = new Vector3(1,1,-1);
			}
			else
			{
				rigidbody2D.gravityScale = gravitiScale;
				gravityCooldown =  Time.time + setGravityCooldown;
				transform.localScale = new Vector3(1,1,1);
			}
		}

		if(transform.position.x < -10f || transform.position.y < -1f || transform.position.y > 12f)
		{
			//Destroy(this.gameObject);
			if(GetComponent<PauzeOption> ().yourScore > PlayerPrefs.GetInt("highScore"))
			{
				PlayerPrefs.SetInt("highScore", GetComponent<PauzeOption> ().yourScore);
			}
			Component ds = this.gameObject.AddComponent("DeadScreen"); //blijft alles hierin elk frame uitvoeren!
			dead = true;
		}

		if(Time.time > changeColliderCooldown)
		{
			changeColliderCooldown = Time.time + setColliderCooldown;
			increaseBoxColliderSize();
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (Time.time > jumpCooldown && playerJump == true)
		{
			playerJump = false;

		}

	}
	void increaseBoxColliderSize()
	{
		if(colliderSize.x < 2)
		{
			colliderSize.x +=0.25f;
			colliderCenter.x -= 0.125f;
			boxCollider.size = colliderSize;
			boxCollider.center = colliderCenter;
		}

	}
	public void gravCdTo0()
	{
		setGravityCooldown = 0f;
	}
}
