using UnityEngine;
using System.Collections;

//gemaakt door Koen en Rocky

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

	public GUISkin myStyle;
	public GUIStyle play;
	public GUIStyle tekst;

	void Start () 
	{	//Bepaal de grootte en positie van de popup vensters.
		PopUp = new Rect(Screen.width / 2, Screen.height / 4, 400, 200);
		PopUp2 = new Rect (Screen.width / 2, Screen.height / 4, 400, 260);

		//play = (Texture)Resources.Load ("play");
	}


	void OnGUI () //maak alle buttons aan van het main menu inclusief de functies die de button uitvoert
	{
		if (GUI.Button (new Rect (Screen.width/20*1,Screen.height/8,200,50),"Start The Science",play))// , "Start The Science")) 
		{ //positie x, positie y, breedte, hoogte
			GameObject.Find ("Game Data").GetComponent <GameData> ().getData();
			Application.LoadLevel(1);
		};
		if (GUI.Button (new Rect (Screen.width/20*2,Screen.height/4,200,50), "How To Play",play)) 
		{// Maakt de andere pop ups onzichtbaar op het moment dat deze word geactiveerd.
			credits = false;
			reset = false;
			options = false;
			howToPlayPopUp();
		};
		if (GUI.Button (new Rect (Screen.width/20*3,Screen.height/8*3,200,50), "Credits",play)) 
		{
			howToPlay = false;
			reset = false;
			options = false;
			creditsPopUp();
		};
		if (GUI.Button (new Rect (Screen.width/20*3,Screen.height/2,200,50), "Options",play)) 
		{ 
			howToPlay=false;
			credits=false;
			reset=false;
			optionPopUp();
			//Debug.Log("Options is open");
		};
		if (GUI.Button (new Rect (Screen.width/20*2,Screen.height/8*5,200,50), "Reset Stats",play)) 
		{
			PlayerPrefs.SetInt ("highScore", 0);
			credits=false;
			howToPlay=false;
			options = false;
			reset = true;

		};

		if (GUI.Button (new Rect (Screen.width/20*1,Screen.height/4*3,200,50), "Quit",play)) 
		{ 
			Application.Quit();
			Debug.Log("game quit");
		};


		//roept de functie aan om te resetten
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
		GUI.skin.toggle = myStyle.toggle;

		GUI.Label(new Rect(20,30,100,50),new GUIContent("Diffuculty"),tekst);
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
		GUI.Label(new Rect(20,130,100,50),new GUIContent("Start speed"),tekst);
		GUI.Label(new Rect(35,150,200,50),new GUIContent("Current speed = " + speed/10),tekst);
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
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Controls"),tekst);
		GUI.Label(new Rect(35, 50, 1000, 50), new GUIContent("Change Gravity: W"),tekst);
		GUI.Label(new Rect(35, 70, 1000, 50), new GUIContent("Jump: Space"),tekst);
		GUI.Label(new Rect(35, 90, 1000, 50), new GUIContent("Pauze: P"),tekst);

		GUI.Label(new Rect(20, 110, 100, 50), new GUIContent("Dead If:"),tekst);
		GUI.Label(new Rect(35, 130, 1000, 50), new GUIContent("Player is out of the screen"),tekst);

		
		
		if (GUI.Button (new Rect(PopUp.width/4,165,PopUp.width/2,25),"Close",play)) 
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
	//<<-----------------------------------how to play layout

	
	//>>-----------------------------------Credits layout
	private void credfunc(int id)
	{
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Developers"),tekst);
		GUI.Label(new Rect(35, 50, 1000, 50), new GUIContent("Rocky Tempelaar"),tekst);
		GUI.Label(new Rect(35, 70, 1000, 50), new GUIContent("Koen Van der Velden"),tekst);
		
		GUI.Label(new Rect(20, 90, 100, 50), new GUIContent("Artists"),tekst);
		GUI.Label(new Rect(35, 110, 1000, 50), new GUIContent("Steven Stier"),tekst);
		GUI.Label(new Rect(35, 130, 1000, 50), new GUIContent("Armand Meghoe"),tekst);
		GUI.Label(new Rect(35, 150, 1000, 50), new GUIContent("Daniël Epke"),tekst);
		GUI.Label(new Rect(35, 170, 1000, 50), new GUIContent("Ludo Domna"),tekst);

		if (GUI.Button (new Rect(PopUp2.width/4,215,PopUp2.width/2,25),"Close",play)) 
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