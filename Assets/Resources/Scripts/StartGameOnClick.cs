﻿using UnityEngine;
using System.Collections;

public class StartGameOnClick : MonoBehaviour 
{

	// Use this for initialization
	void Start () {

	}

	void OnMouseDown()  
	{
		Application.LoadLevel("MainScreen");
	}

	// Update is called once per frame
	void Update () {

	}
}
