using UnityEngine;
using System.Collections;

//gemaakt door Koen en Rocky

public class DeadScreen : MonoBehaviour {
	
	private Rect PopUp;

	public GUIStyle play;
	public GUIStyle tekst;
	public AudioSource Scream;

	int score;
	// Use this for initialization

	void Start () {
		PopUp = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200);

		//haalt textures op
		play = GetComponent<PauzeOption> ().play;
		tekst = GetComponent<PauzeOption> ().tekst;
	}

	private void OnGUI(){
		//start als de player dood is en word dan dus zichtbaar
		if(GetComponent<PlayerMovement> ().dead == true)
		{
		PopUp = GUI.Window (0, PopUp, deadFunc, "Game over");
		Time.timeScale = 0;

			Scream.audio.Play();
		}
	}

	//inhoud van het dead screen
	void deadFunc(int id)
	{
		GUI.Label (new Rect(100,50,200,200), "your final score = " + GetComponent<PauzeOption>().yourScore,tekst);

		if(GetComponent<PauzeOption> () .yourScore == PlayerPrefs.GetInt("highScore"))
		{
			GUI.Label (new Rect(100,70,200,200), "You have beaten your highscore!",tekst);
		}
		
		GUI.Label (new Rect(100,90,200,200), "your high score = " + PlayerPrefs.GetInt("highScore"),tekst);

		if (GUI.Button (new Rect(10,160,130,30), "Restart the game",play))  //positie x, positie y, breedte, hoogte
		{
			Application.LoadLevel(1);
		};

		if (GUI.Button (new Rect(240,160,130,30), "Main menu",play)) 
		{
			GameObject.Find ("Game Data").GetComponent <GameData> ().destroy();
			Application.LoadLevel(0);
		};
	}
}