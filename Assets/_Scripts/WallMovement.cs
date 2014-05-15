using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour {

	float speed = 10;
	public Transform otherWall;

	void Update () 
	{
		if(transform.position.x <= -30f)
		{
			Vector3 temp = otherWall.position; // copy to an auxiliary variable...
			temp.x += 30f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
			Destroy(transform.GetChild(0).gameObject);
		}

		transform.Translate(-1 * Time.deltaTime * speed,0,0);
	}
}
