using UnityEngine;
using System.Collections;

// Koen

public class HomeScreen : MonoBehaviour 
{
	private Rect PopUp2;
	private Rect PopUp;
	private bool howToPlay = false;
	private bool credits = false;
	private bool reset = false;
	private bool options = false;

	public bool easy = true;
	public bool medium = false;
	public bool hard = false;

	public float speed = 10f;

	void Start () 
	{	//Bepaal de grootte en positie van de popup vensters.
		PopUp = new Rect(Screen.width / 2, Screen.height / 4, 400, 200);
		PopUp2 = new Rect (Screen.width / 2, Screen.height / 4, 400, 260);
	}


	void OnGUI () //maak alle buttons aan van het main menu inclusief de functies die de button uitvoert
	{
		if (GUI.Button (new Rect (Screen.width/20*1,Screen.height/8,200,30), "Start The Science")) 
		{ //positie x, positie y, breedte, hoogte
			Application.LoadLevel(1);
		};
		if (GUI.Button (new Rect (Screen.width/20*2,Screen.height/4,200,30), "How To Play")) 
		{// Maakt de andere pop ups onzichtbaar op het moment dat deze word geactiveerd.
			credits = false;
			reset = false;
			options = false;
			howToPlayPopUp();
		};
		if (GUI.Button (new Rect (Screen.width/20*3,Screen.height/8*3,200,30), "Credits")) 
		{
			howToPlay = false;
			reset = false;
			options = false;
			creditsPopUp();
		};
		if (GUI.Button (new Rect (Screen.width/20*4,Screen.height/2,200,30), "Options")) 
		{ 
			howToPlay=false;
			credits=false;
			reset=false;
			optionPopUp();
			Debug.Log("Options is open");
		};
		if (GUI.Button (new Rect (Screen.width/20*5,Screen.height/8*5,200,30), "Reset stats")) 
		{
			PlayerPrefs.SetInt ("highScore", 0);
			credits=false;
			howToPlay=false;
			options = false;
			reset = false;
		};

		if (GUI.Button (new Rect (Screen.width/20*6,Screen.height/4*3,200,30), "Quit")) 
		{ 
			Application.Quit();
			Debug.Log("game quit");
		};


		//start en roept de functie aan om te resetten
		if (reset) 
		{
			GUI.Label(new Rect(Screen.width/2,Screen.height/4,400,200),"Your data has been reset");

			Invoke ("Reset", 3);
		}

		//open het option menu
		if (options)
		{
			PopUp = GUI.Window(0,PopUp,optionfunc,"Options");
		}
		//start de how to play popup
		if (howToPlay) 
		{
			PopUp = GUI.Window(0,PopUp,howFunc,"How to play the game.");
		}

		//start de credits popup
		if (credits) 
		{
			PopUp2 = GUI.Window(0,PopUp2,credfunc,"Credits");
		}
	}

	//>>-----------------------------------Options layout
	private void optionfunc (int id)
	{
		GUI.Label(new Rect(20,30,100,50),new GUIContent("Diffuculty"));
		GUILayout.BeginArea(new Rect(40,50,200,200));
			easy = GUILayout.Toggle (easy, " Easy");

		if (easy) 
		{
			hard = false;
			medium = false;
		}

			medium = GUILayout.Toggle (medium, " Medium");

		if (medium)
		{
			easy = false;
			hard = false;
		}

			hard = GUILayout.Toggle (hard, " Hard");

		if (hard) 
		{
			easy = false;
			medium = false;
		}

		GUILayout.EndArea ();
		GUI.Label(new Rect(20,130,100,50),new GUIContent("Start speed"));
		GUI.Label(new Rect(35,150,200,50),new GUIContent("Current speed = " + speed/10));
		GUILayout.BeginArea (new Rect (55, 170, 100, 50));
		speed = GUILayout.HorizontalSlider (speed, 5f, 30f);
		GUILayout.EndArea ();
	}

	void optionPopUp()
	{
		
		if (options) {
			options = false;
		} 
		else 
		{
			options = true;
		}
		
	}
	//<<-----------------------------------Options layout
	

	//>>-----------------------------------how to play layout
	private void howFunc(int id)
	{
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Controls"));
		GUI.Label(new Rect(35, 50, 1000, 50), new GUIContent("Change Gravity: W"));
		GUI.Label(new Rect(35, 70, 1000, 50), new GUIContent("Jump: Space"));
		GUI.Label(new Rect(35, 90, 1000, 50), new GUIContent("Pauze: P"));

		GUI.Label(new Rect(20, 110, 100, 50), new GUIContent("Dead If:"));
		GUI.Label(new Rect(35, 130, 1000, 50), new GUIContent("Player is out of the screen"));

		
		
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
	//<<-----------------------------------Credits

	
	//>>-----------------------------------Credits layout
	private void credfunc(int id)
	{
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Developers"));
		GUI.Label(new Rect(35, 50, 1000, 50), new GUIContent("Rocky Tempelaar"));
		GUI.Label(new Rect(35, 70, 1000, 50), new GUIContent("Koen Van der Velden"));
		
		GUI.Label(new Rect(20, 90, 100, 50), new GUIContent("Artists"));
		GUI.Label(new Rect(35, 110, 1000, 50), new GUIContent("test"));
		GUI.Label(new Rect(35, 130, 1000, 50), new GUIContent("test"));
		GUI.Label(new Rect(35, 150, 1000, 50), new GUIContent("test"));
		GUI.Label(new Rect(35, 170, 1000, 50), new GUIContent("test"));

		if (GUI.Button (new Rect(25,215,350,25),"Close")) 
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
	//<<-----------------------------------Credits

	//sluit de reset
	void Reset()
	{
		reset = false;
	}
}