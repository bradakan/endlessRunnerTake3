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
	private int diff;


	void Start()
	{
		GameObject gameData = GameObject.Find ("Game Data");
		speed = gameData.GetComponent<GameData> ().gameSpeed;
		diff = gameData.GetComponent<GameData> ().Diff;
	}
	
	void Update () 
	{

		if(transform.position.x <= -30f)
		{
			Vector3 temp = otherWall.position; // copy to an auxiliary variable...
			temp.x += 30f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
			Destroy(transform.GetChild(0).gameObject);
			GameObject chunk = Instantiate(walls[Random.Range(0,diff)], temp, transform.rotation) as GameObject;
			chunk.transform.parent = transform;
		}



		transform.Translate(-1 * speed * Time.deltaTime,0,0);

		if(Time.time > speedCooldown)
		{
			speed *= 1.05f;
			if(speed > 20)
			{
				GameObject.Find("Runner").GetComponent<PlayerMovement>().gravCdTo0();
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
				GameObject.Find("Runner").GetComponent<PlayerMovement>().increaseBoxColliderSize();
			}
			speedCooldown = Time.time + speedSetCooldown;
		}

	}
}
