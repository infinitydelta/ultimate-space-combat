﻿using UnityEngine;
using System.Collections;

public class GUIscore : MonoBehaviour {
	Ship ship;
	// Use this for initialization
	void Start () {
		ship = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship> ();

	}
	
	// Update is called once per frame
	void Update () {
		guiText.text =  ship.score.ToString();

	}
}
