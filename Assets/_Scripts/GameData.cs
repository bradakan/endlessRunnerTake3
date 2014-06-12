using UnityEngine;
using System.Collections;

//gemaakt door Koen en Rocky

// Slaat de data uit het option screen op.
public class GameData : MonoBehaviour 
{


	public float gameSpeed;
	public int Diff;
	private bool Easy;
	private bool Medium;
	private bool Hard;

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	// Update is called once per frame
	public void getData()
	{
		// de volgende data word opgeslagen vanuit het home screen op het moment dat de speler de game start.

		gameSpeed = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().speed;
		//Debug.Log (gameSpeed);

		Easy = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().easy;
		Hard = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().hard;
		Medium = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().medium;

		if (Easy == true) 
		{
			Diff = 5;
		}
		if (Medium == true) 
		{
			Diff = 10;
		}
		if (Hard == true) 
		{
			Diff = 14;
		}
	}

	//Maakt dit game object stuk als je terug naar de home screen gaat.
	public void destroy()
	{
		Destroy (this.gameObject);
	}
}