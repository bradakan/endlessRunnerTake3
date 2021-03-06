﻿using UnityEngine;
using System.Collections;

//gemaakt door Koen en Rocky

public class PauzeOption : MonoBehaviour 
{

	private Rect PauzePopUp;
	private Rect HowPopUp;
	public bool paused = false;
	public bool howToPlay = false;
	public int yourScore = 0;

	public GUIStyle play;
	public GUIStyle tekst;

	void Start () 
	{
		//maakt de grootte van de windows

		PauzePopUp = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 230);

		HowPopUp = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200);
	}


	void Update () {

		//als p is ingedrukt en de player leeft nog
		if (Input.GetKeyUp(KeyCode.P) && GetComponent<PlayerMovement>().dead == false)
		{
			//if paused = true.
			if (paused)
			{
				paused = false;
			}
			else
			{
				paused = true;
			}
		}
		//zet de beweging stil
		if (paused || howToPlay)
						Time.timeScale = 0;
				else 
						Time.timeScale = 1;
				
		//telt de score op zolang de player leeft & pauze of how to play niet is geopent
		if(GetComponent<PlayerMovement>().dead == false && paused == false && howToPlay==false)
		{
			yourScore++;
		}
	}
	
	void OnGUI()
	{
		//betekenis pauze menu
		if (paused) 
		{
			PauzePopUp = GUI.Window(0,PauzePopUp,pauzeFunc,"Pauze Menu");
		}

		//betekenis how to play menu
		if (howToPlay) 
		{
			paused = false;
			HowPopUp = GUI.Window(0,HowPopUp,howFunc,"How to play the game.");
		}

		//laat je score zien in je scherm op het moment dat je de game speelt.
		if (GetComponent<PlayerMovement> ().dead == false) 
		{
			GUI.Label (new Rect (Screen.width / 10 * 8, Screen.height / 20 * 1, 200, 200), "your current score: " + yourScore,tekst);
		}

	}

	//>>---------------------------Pauze layout
	private void pauzeFunc(int id)
	{
		if (GUI.Button(new Rect(20,25,PauzePopUp.width-40,30), "Continue",play)) 
		{
			paused = false;
		}

		if (GUI.Button(new Rect(20,65,PauzePopUp.width-40,30), "Restart",play))
		{
			Application.LoadLevel(1);
		}

		if (GUI.Button(new Rect(20,105,PauzePopUp.width-40,30), "How To Play",play))
		{
			howToPlayPopUp();
		}

		if (GUI.Button(new Rect(20,145,PauzePopUp.width-40,30), "Main Menu",play))
		{
			
			GameObject.Find ("Game Data").GetComponent <GameData> ().destroy();
			Application.LoadLevel(0);
		}

		if (GUI.Button(new Rect(20,185,PauzePopUp.width-40,30), "Exit",play))
		{
			Application.Quit();
		}


	}
	//<<---------------------------Pauze layout

	//>>---------------------------how to play layout
	private void howFunc(int id)
	{
		GUI.Label(new Rect(20, 30, 100, 50), new GUIContent("Controls"),tekst);
		GUI.Label(new Rect(35, 50, 300, 50), new GUIContent("Change Gravity: W"),tekst);
		GUI.Label(new Rect(35, 70, 300, 50), new GUIContent("Jump: Space"),tekst);
		GUI.Label(new Rect(35, 90, 300, 50), new GUIContent("Pauze: P"),tekst);
		
		GUI.Label(new Rect(20, 110, 100, 50), new GUIContent("Dead If:"),tekst);
		GUI.Label(new Rect(35, 130, 300, 50), new GUIContent("Player is out of the screen"),tekst);
		
		
		
		if (GUI.Button (new Rect(HowPopUp.width/4,165,HowPopUp.width/2,25),"Close",play)) 
		{
			howToPlay = false;
			paused = true;
		}
	}

	//<<---------------------------how to play layout

	//sluit en sluit de how to play
	void howToPlayPopUp()
	{
		if (howToPlay)
		{
			howToPlay = false;
		}
		else
		{
			howToPlay = true;
		}
	}


}