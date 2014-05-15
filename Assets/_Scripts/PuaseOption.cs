using UnityEngine;
using System.Collections;

public class PuaseOption : MonoBehaviour {

	private Rect PauzePopUp;
	private Rect HowPopUp;
	private bool paused = false;
	private bool howToPlay = false;


	void Start () {
		PauzePopUp = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);

		HowPopUp = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200);
	}
	void Update () {
		if (Input.GetKeyUp(KeyCode.P))
		{
			if (paused)
			{
				paused = false;
			}
			else
			{
				paused = true;
			}
		}
		if (paused || howToPlay)
						Time.timeScale = 0;
				else
						Time.timeScale = 1;
	}

	void OnGUI()
	{
		if (paused) 
		{
			PauzePopUp = GUI.Window(0,PauzePopUp,pauzeFunc,"Pauze Menu");
		}

		if (howToPlay) 
		{
			paused = false;
			HowPopUp = GUI.Window(0,HowPopUp,howFunc,"How to play the game.");
		}
	}
	
	private void pauzeFunc(int id)
	{
		if (GUILayout.Button ("doorgaan")) 
		{
			paused = false;
		}

		if (GUILayout.Button ("restart")) 
		{
			Application.LoadLevel(1);
		}

		if (GUILayout.Button ("How to play")) 
		{
			howToPlayPopUp();
		}

		if (GUILayout.Button ("Main menu")) 
		{
			Application.LoadLevel(0);
		}

		if (GUILayout.Button ("Exit")) 
		{
			Application.Quit();
		}


	}


	private void howFunc(int id)
	{
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Controls"));
		GUI.Label(new Rect(35, 50, 1000, 50), new GUIContent("Change Gravity: W"));
		GUI.Label(new Rect(35, 70, 1000, 50), new GUIContent("Jump: Space"));
		
		GUI.Label(new Rect(20, 90, 100, 50), new GUIContent("Dead If:"));
		GUI.Label(new Rect(35, 110, 1000, 50), new GUIContent("Player is out of the screen"));
		
		
		
		if (GUI.Button (new Rect(0,165,400,25),"Close")) 
		{
			howToPlay = false;
			paused = true;
		}
	}

	void howToPlayPopUp()
	{
		if (howToPlay)
		{
			howToPlay = false;
			//Debug.Log("hij werkt");
		}
		else
		{
			howToPlay = true;
		}
	}

}