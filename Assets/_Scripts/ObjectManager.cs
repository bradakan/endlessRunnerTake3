using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectManager : MonoBehaviour {

	public GameObject runnerRef;
	public float distanceToRecycle = 20;
	public int numberOfWalls = 5;
	public int movement = -5;
	public GameObject[] ObjectVerzameling;
	public int randomWall = Random.Range(1,4);



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (randomWall);

	
	}
}
