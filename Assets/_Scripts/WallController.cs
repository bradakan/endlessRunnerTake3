using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//gemaakt door Koen en Rocky

public class WallController : MonoBehaviour {

	//the target that it moves behind
	public Transform otherWall;

	float speed = 10f;
	public List<GameObject> walls = new List<GameObject>();
	public float timeScale = 1;
	public int diff;
	float speedSetCooldown = 5;
	float speedCooldown = 5;


	void Start()
	{
		GameObject gameData = GameObject.Find ("Game Data");
		speed = gameData.GetComponent<GameData> ().gameSpeed;
		diff = gameData.GetComponent<GameData> ().Diff;
	}
	
	void Update () 
	{
		//this moves the wall chunk behind the other one
		if(transform.position.x <= -30f)
		{
			Vector3 temp = otherWall.position; // copy to an auxiliary variable...
			temp.x += 30f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
			Destroy(transform.GetChild(0).gameObject);
			GameObject chunk = Instantiate(walls[Random.Range(0,diff)], temp, transform.rotation) as GameObject;
			chunk.transform.parent = transform;
		}


		//wall movement
		transform.Translate(-1 * speed * Time.deltaTime,0,0);

		//the speed cooldown
		if(Time.time > speedCooldown)
		{
			speed *= 1.05f;
			if(speed > 20)
			{
				//remiving the gravity switch cooldown
				GameObject.Find("Runner").GetComponent<PlayerMovement>().gravCdTo0();

				//in case you start at a higher speed this is needed so you dont teleport trough walls
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
			}
			//setting the cooldown
			speedCooldown = Time.time + speedSetCooldown;
		}

	}
}
