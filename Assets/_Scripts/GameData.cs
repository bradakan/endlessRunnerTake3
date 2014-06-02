using UnityEngine;
using System.Collections;
// Slaat de data uit het option screen op.
public class GameData : MonoBehaviour 
{


	public float gameSpeed;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameSpeed = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().speed;
		Debug.Log (gameSpeed);
	}
}