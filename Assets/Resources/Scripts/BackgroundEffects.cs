using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundEffects : MonoBehaviour {

	int maxObjects = 40;
	int numOfObjects = 0;
	int maxObjectsFast = 40;
	int numOfObjectsFast = 0;
	Vector3 minX;
	Vector3 maxX;
	Vector3 randomPos;
	public GameObject[] bgSprites;
	GameObject temp;
	List <GameObject> bgObjects = new List <GameObject>();
	List <GameObject> bgObjectsFast = new List <GameObject>();

	// Use this for initialization
	void Start () {

		minX = camera.ScreenToWorldPoint(new Vector3(-25,0,10));
		maxX = new Vector3 (minX.x * -2, 0, 10);

		while(numOfObjects<maxObjects){
			//generate random bg object and display in random place
			randomPos = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 10);
			temp = ((GameObject)Instantiate(bgSprites[Random.Range(0, bgSprites.Length)],camera.ScreenToWorldPoint(randomPos),Quaternion.identity));
			bgObjects.Add(temp); //fill the list
			numOfObjects++; //increment
		}

		while (numOfObjectsFast<maxObjectsFast) {
			randomPos = new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), 10);
			temp = ((GameObject)Instantiate (bgSprites [Random.Range (0, bgSprites.Length)], camera.ScreenToWorldPoint (randomPos), Quaternion.identity));
			bgObjectsFast.Add (temp); //fill the list
			numOfObjectsFast++; //increment
		}
	}

	// Update is called once per frame
	void Update () 
	{
		//move the objects left over time
		foreach (GameObject k in bgObjects) {
			k.transform.Translate(Vector3.left * Time.deltaTime);

			if(k.transform.position.x < minX.x){ 
				k.transform.Translate(maxX);
			}
		}

		foreach (GameObject l in bgObjectsFast) {
			l.transform.Translate(Vector3.left * Time.deltaTime * 2);
			
			if(l.transform.position.x < minX.x){
				l.transform.Translate(maxX);
			}
		}

		/*
		if (numOfObjects < maxObjects) {
			randomPos = new Vector3(Screen.width, Random.Range(0, Screen.height), 10);
			temp = ((GameObject)Instantiate(bgSprites[Random.Range(0, bgSprites.Length)],
			                                camera.ScreenToWorldPoint(randomPos),Quaternion.identity));
			bgObjects.Add(temp);
			numOfObjects++;
		}

		if (numOfObjectsFast < maxObjectsFast) {
			randomPos = new Vector3(Screen.width, Random.Range(0, Screen.height), 10);
			temp = ((GameObject)Instantiate(bgSprites[Random.Range(0, bgSprites.Length)],
			                                camera.ScreenToWorldPoint(randomPos),Quaternion.identity));
			bgObjectsFast.Add(temp);
			numOfObjectsFast++;
		}*/

	}
}
