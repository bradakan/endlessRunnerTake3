using UnityEngine;
using System.Collections;

//gemaakt door Koen en Rocky

public class backgroundMovement : MonoBehaviour {

	public Transform chunk;

	
	// all this does is following the target calld chunk here 
	void Update () 
	{
		Vector3 temp = chunk.position;
		temp.y = 4.5f;
		temp.z = 2f;
		transform.position = temp;
	}
}
