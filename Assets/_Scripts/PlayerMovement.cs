using UnityEngine;
using System.Collections;

//gemaakt door Koen en Rocky

public class PlayerMovement : MonoBehaviour {

	//the gravityscale i am using
	public float gravitiScale = 5f;
	//jump height
	public float jumpForce = 1000f;

	//cooldowns
	float gravityCooldown = 0f;
	float jumpCooldown = 0f;
	float changeColliderCooldown = 20f;

	//setting the cooldowns to this number when they trigger
	float setColliderCooldown = 20f;
	float setGravityCooldown = 1f;
	float setJumpCooldown = 0.5f;

	//i use this to increase the collider size 
	BoxCollider2D boxCollider;
	Vector2 colliderSize;
	Vector2 colliderCenter;

	//here i see if i am jumping or not
	bool playerJump;


	Animator anim;

	public AudioSource Jump;
	public AudioSource Gravity;
	public AudioSource Run;
	public AudioSource Scream;

	//am i dead?
	public bool dead = false;
	

	// Use this for initialization
	void Start () 
	{

		anim = GameObject.Find("GameObject_Char").GetComponent<Animator>();
		playerJump = false;
		rigidbody2D.gravityScale = gravitiScale;
		boxCollider = gameObject.collider2D as BoxCollider2D;//GetComponent(BoxCollider2D);
		colliderSize = boxCollider.size;
		colliderCenter = boxCollider.center;

	}
	
	// Update is called once per frame
	void Update () 
	{
		//if the character is out of center it will move slowly towards the center
		if(transform.position.x <= 0)
		{
			transform.Translate(0.5f * Time.deltaTime,0,0);
		}

		//jumping
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(playerJump == false && rigidbody2D.gravityScale == gravitiScale)
			{
				rigidbody2D.AddForce(new Vector2(0,jumpForce));
				playerJump = true;
				jumpCooldown = Time.time + setJumpCooldown;
				anim.SetBool("JumpAnim", true);
				Jump.audio.Play();

			}
			if(playerJump == false && rigidbody2D.gravityScale == -gravitiScale)
			{
				rigidbody2D.AddForce(new Vector2(0,-jumpForce));
				playerJump = true;
				jumpCooldown = Time.time + setJumpCooldown;
				anim.SetBool("JumpAnim", true);
				Jump.audio.Play();

			}
		}

		//switching the gravity
		if(Input.GetKeyDown (KeyCode.W) && Time.time > gravityCooldown)
		{
			if(rigidbody2D.gravityScale >= gravitiScale)
			{
				rigidbody2D.gravityScale = -gravitiScale;
				gravityCooldown =  Time.time + setGravityCooldown;
				transform.localScale = new Vector3(1,-1,1);
				Gravity.audio.Play();

			}
			else
			{
				rigidbody2D.gravityScale = gravitiScale;
				gravityCooldown =  Time.time + setGravityCooldown;
				transform.localScale = new Vector3(1,1,1);
				Gravity.audio.Play();
			}
		}

		//the is the script that makes you dead
		if(transform.position.x < -10f || transform.position.y < -1f || transform.position.y > 12f && dead == false)
		{
			Scream.audio.Play();
			//Destroy(this.gameObject);
			if(GetComponent<PauzeOption> ().yourScore > PlayerPrefs.GetInt("highScore"))
			{
				PlayerPrefs.SetInt("highScore", GetComponent<PauzeOption> ().yourScore);
			}
			dead = true;
		}

		//increases the collider size over time
		if(Time.time > changeColliderCooldown)
		{
			changeColliderCooldown = Time.time + setColliderCooldown;
			increaseBoxColliderSize();
		}
	}

	//allows you to jump again and enables the run sound
	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (Time.time > jumpCooldown && playerJump == true)
		{
			playerJump = false;
			anim.SetBool("JumpAnim", false);
			Run.audio.Play();
		}
	}
	
	public void increaseBoxColliderSize()
	{
		if(colliderSize.x < 2)
		{
			colliderSize.x +=0.25f;
			colliderCenter.x -= 0.125f;
			boxCollider.size = colliderSize;
			boxCollider.center = colliderCenter;
		}

	}

	//if the speed id high enough you do not have a gravity cooldown anymore
	public void gravCdTo0()
	{
		setGravityCooldown = 0f;
	}
}
