using UnityEngine;
using System.Collections;

// Koen

public class HomeScreen : MonoBehaviour {
	private Rect PopUp;
	private bool howToPlay = false;
	private bool credits = false;

	
	void Start () {
		PopUp = new Rect(Screen.width / 8 * 4, Screen.height / 4*1, 400, 200);
	}


	void OnGUI () 
	{
		if (GUI.Button (new Rect (Screen.width/20*2,350,200,30), "Start The Science")) { //positie x, positie y, breedte, hoogte
			Application.LoadLevel(1);
		};
		if (GUI.Button (new Rect (Screen.width/20*3,400,200,30), "How To Play")) { //positie x, positie y, breedte, hoogte
			credits = false;
			howToPlayPopUp();
		};
		if (GUI.Button (new Rect (Screen.width/20*4,450,200,30), "Credits")) { //positie x, positie y, breedte, hoogte
			howToPlay = false;
			creditsPopUp();
		};
		if (GUI.Button (new Rect (Screen.width/20*5,500,200,30), "Quit")) { //positie x, positie y, breedte, hoogte
			Application.Quit();
			Debug.Log("game is gestopt");
		};




		
		if (howToPlay) 
		{
			PopUp = GUI.Window(0,PopUp,howFunc,"How to play the game.");
		}

		if (credits) 
		{
			PopUp = GUI.Window(0,PopUp,credfunc,"Credits");
		}
	}

	private void howFunc(int id)
	{
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Controls"));
		GUI.Label(new Rect(35, 50, 1000, 50), new GUIContent("Change Gravity: W"));
		GUI.Label(new Rect(35, 70, 1000, 50), new GUIContent("Jump: Space"));

		GUI.Label(new Rect(20, 90, 100, 50), new GUIContent("Dead If:"));
		GUI.Label(new Rect(35, 110, 1000, 50), new GUIContent("Player is out of the screen"));

		
		
		if (GUI.Button (new Rect(25,165,350,25),"Close")) 
		{
			howToPlay = false;
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
	private void credfunc(int id)
	{
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Developers"));
		GUI.Label(new Rect(35, 50, 1000, 50), new GUIContent("Rocky Tempelaar"));
		GUI.Label(new Rect(35, 70, 1000, 50), new GUIContent("Koen Van der Velden"));
		
		GUI.Label(new Rect(20, 90, 100, 50), new GUIContent("Artists"));
		GUI.Label(new Rect(35, 110, 1000, 50), new GUIContent("test"));

		if (GUI.Button (new Rect(25,165,350,25),"Close")) 
		{
			credits = false;
		}
	}
	void creditsPopUp()
	{
				
		if (credits) {
			credits = false;
		} 
		else 
		{
			credits = true;
		}
				
	}
}