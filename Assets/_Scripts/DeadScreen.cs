using UnityEngine;
using System.Collections;

public class DeadScreen : MonoBehaviour {

	private Rect PopUp;
	// Use this for initialization
	void Start () {
		PopUp = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200);
	}

	void Update(){
		Time.timeScale = 0;
		}
	public void OnGUI(){
		PopUp = GUI.Window (0, PopUp, deadFunc, "Game over");
	}

	void deadFunc(int id)
	{
		GUILayout.BeginArea (new Rect (10,160,150,150));
		if (GUILayout.Button ("Restart the game"))  //positie x, positie y, breedte, hoogte
		{
			Application.LoadLevel(1);
		};
		GUILayout.EndArea();

		GUILayout.BeginArea (new Rect (240,160,150,150));
		if (GUILayout.Button ("Main menu")) 
		{
			Application.LoadLevel(0);
		};
		GUILayout.EndArea();
	}
}
