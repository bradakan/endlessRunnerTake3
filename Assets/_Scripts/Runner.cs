using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public int movement = 5;
	public float speed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (movement * Time.deltaTime, 0));
		rigidbody.AddForce (new Vector3 (speed, 0, 0), ForceMode.Acceleration);
	
	}
}
