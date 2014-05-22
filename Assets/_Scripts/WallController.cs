using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallController : MonoBehaviour {
	
	float speed = 10f;
	public Transform otherWall;
	public List<GameObject> walls = new List<GameObject>();
	float speedSetCooldown = 5;
	float speedCooldown = 5;
	public float timeScale = 1;


	
	void Update () 
	{

		if(transform.position.x <= -30f)
		{
			Vector3 temp = otherWall.position; // copy to an auxiliary variable...
			temp.x += 30f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
			Destroy(transform.GetChild(0).gameObject);
			GameObject chunk = Instantiate(walls[Random.Range(0,walls.Count)], temp, transform.rotation) as GameObject;
			chunk.transform.parent = transform;
		}



		transform.Translate(-1 * speed * Time.deltaTime,0,0);

		if(Time.time > speedCooldown)
		{
			speed *= 1.05f;
			if(speed > 20)
			{
				GameObject.Find("Runner").GetComponent<PlayerMovement>().gravCdTo0();
			}
			speedCooldown = Time.time + speedSetCooldown;
		}

	}
}
