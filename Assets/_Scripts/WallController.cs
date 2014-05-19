using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallController : MonoBehaviour {
	
	float speed = 10;
	public Transform otherWall;
	public List<GameObject> walls = new List<GameObject>();
	float speedSetCooldown = 5;
	float speedCooldown = 5;
	float timeScale = 1;


	
	void Update () 
	{

		if(transform.position.x <= -30f)
		{
			Vector3 temp = otherWall.position; // copy to an auxiliary variable...
			temp.x += 30f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
			Destroy(transform.GetChild(0).gameObject);
			GameObject chunk = Instantiate(walls[Random.Range(0,walls.Count)], transform.position, transform.rotation) as GameObject;
			chunk.transform.parent = transform;
		}


		transform.Translate(-1 * Time.deltaTime * speed,0,0);
		if(Time.time > speedCooldown)
		{
			//sets the cooldown for the increased speed
			speedCooldown = Time.time + speedSetCooldown;
			//speed *= 1.1f;
			timeScale += 0.1f;
			Time.timeScale = timeScale;
		}

	}
}
