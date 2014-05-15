/*using UnityEngine;
using UnityEngine;
using System.Collections;
//using System.Collections.Generic;


public class ObjectManager : MonoBehaviour {
	
	public GameObject runnerRef;
	public float distanceToRecycle = 20;
	public int numberOfWalls = 5;
	public int movement = -5;
	public GameObject[] ObjectVerzameling;
	static int randomWall = Random.Range(1,4);
	
	
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		randomWall = Random.Range (1, 4);
		
		Debug.Log (randomWall);
		
		transform.Translate (new Vector2 (movement * Time.deltaTime, 0));
		
		
	}
}
*/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour 
{
	//dit script is gemaakt door Koen
	//dit script was om de levelchunks te generaten maar het werkte niet zoals we wilde dus er word een nieuwe generator gemaakt


	public GameObject runnerRef;
	public float distanceToRecycle = 20;
	public int numberOfWalls = 4;
	public int movement = -5;
	//public GameObject [] walls = new GameObject[3];
	public List<GameObject> wall = new List<GameObject>();
	
//	static int randomWall = Random.Range(1,4);
	
	void Start () 
	{
		
		
		
		
		/*GameObject wallPrefab = wall[Random.Range(1,wall.Count)];
		for (int i=0; i<numberOfWalls; i++) 
		{
			GameObject b = Instantiate (wallPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			Vector3 tempPos = new Vector3();
			if(wall.Count>0)
			{
				tempPos = wall[wall.Count-1].transform.position;
				tempPos.x += b.transform.localScale.x*.5f*35;
			}
			b.transform.position = tempPos;
			b.transform.parent = gameObject.transform;
			wall.Add(b);
		}*/
	}
	// Update is called once per frame
	void Update () {
		
		//randomWall = Random.Range (1, 4);
		//Debug.Log (randomWall);
		//Debug.Log(wall.Count);

		
		transform.Translate (new Vector2 (movement * Time.deltaTime, 0));


		GameObject wallPrefab = wall[Random.Range(1,wall.Count)];
		for (int i=0; i<numberOfWalls; i++) 
		{
			GameObject b = Instantiate (wallPrefab) as GameObject;
			Vector3 tempPos = new Vector3();
			if(wall.Count>6)
			{
				tempPos = wall[wall.Count-1].transform.position;
				tempPos.x += b.transform.localScale.x*.5f*35;
			}
			b.transform.position = tempPos;
			b.transform.parent = gameObject.transform;
			wall.Add(b);
		}
		Mathf


		if (wall[0].transform.position.x + distanceToRecycle < runnerRef.transform.position.x) 
		{
			var b = wall[0];
			wall.RemoveAt(0);
			
//			GameObject wallPrefab = wall[Random.Range(1,wall.Count)];

			
			Vector3 tempPos = new Vector3();
			if(wall.Count>0)
			{
				Debug.Log(wall.Count);
				tempPos = wall[wall.Count-1].transform.position;
				tempPos.x += b.transform.localScale.x;
			}
			b.transform.position = tempPos;
			b.transform.parent = gameObject.transform;
			wall.Add(b);
		}
	}
}