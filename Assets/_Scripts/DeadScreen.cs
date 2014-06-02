using UnityEngine;
using System.Collections;

public class DeadScreen : MonoBehaviour {

	private Rect PopUp;
	int score;
	// Use this for initialization
	void Start () {
		PopUp = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200);
		score = GetComponent<PauzeOption> ().yourScore;
	}

	void Update(){
		Time.timeScale = 0;
		}
	public void OnGUI(){
		PopUp = GUI.Window (0, PopUp, deadFunc, "Game over");
	}

	void deadFunc(int id)
	{
		GUILayout.BeginArea(new Rect(100,50,200,200));
		GUILayout.Label ("your final score = " + score);
		GUILayout.EndArea();

		if(GetComponent<PauzeOption> () .yourScore == PlayerPrefs.GetInt("highScore"))
		{
			GUILayout.BeginArea(new Rect(100,70,200,200));
			GUILayout.Label ("You have beaten your highscore!");
			GUILayout.EndArea();
		}

		GUILayout.BeginArea(new Rect(100,90,200,200));
		GUILayout.Label ("your high score = " + PlayerPrefs.GetInt("highScore"));
		GUILayout.EndArea();

		GUILayout.BeginArea (new Rect (10,160,150,150));
		if (GUILayout.Button ("Restart the game"))  //positie x, positie y, breedte, hoogte
		{
			Application.LoadLevel(1);
		};
		GUILayout.EndArea();

		GUILayout.BeginArea (new Rect (240,160,150,150));
		if (GUILayout.Button ("Main menu")) 
		{
			GameObject.Find ("Game Data").GetComponent <GameData> ().destroy();
			Application.LoadLevel(0);
		};
		GUILayout.EndArea();
	}
}