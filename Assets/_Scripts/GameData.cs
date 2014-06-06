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
		gameSpeed = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().speed;
		Debug.Log (gameSpeed);

		Easy = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().easy;
		Hard = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().medium;
		Medium = GameObject.Find ("Main Camera").GetComponent <HomeScreen> ().hard;

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


	public void destroy()
	{
		Destroy (this.gameObject);
	}
}