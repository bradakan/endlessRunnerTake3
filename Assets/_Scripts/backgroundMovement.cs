using UnityEngine;
using System.Collections;

public class backgroundMovement : MonoBehaviour {

	public Transform chunk;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 temp = chunk.position; // copy to an auxiliary variable...
		temp.y = 4.5f;
		temp.z = 2f;
		transform.position = temp;
	}
}
