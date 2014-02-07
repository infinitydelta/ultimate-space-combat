using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	Ship ship;
	// Use this for initialization
	void Start () {
		ship = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship> ();
	}
	
	// Update is called once per frame
	void Update () {
		//int eng = ship.GetComponent<Ship> ().energy;
		//print (ship.GetComponent<Ship>().energy);
		guiText.text =  ship.energy.ToString();
	}
}
