using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	bool playerJump;
	public float gravitiScale = 5;
	public float jumpForce = 1000;
	float gravityCooldown = 0;
	public float setGravityCooldown = 1;
	float jumpCooldown = 0;
	float setJumpCooldown = 0.5f;
	// Use this for initialization
	void Start () 
	{
		playerJump = false;
		rigidbody2D.gravityScale = gravitiScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (Time.time);
		if(transform.position.x <= 0)
		{
			transform.Translate(1 * Time.deltaTime,0,0);
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
			if(rigidbody2D.gravityScale == gravitiScale)
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
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (Time.time > jumpCooldown && playerJump == true)
		{
			playerJump = false;
			Debug.Log ("ik zie collision");
		}

	}
}
