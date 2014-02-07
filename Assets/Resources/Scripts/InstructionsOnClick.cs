using UnityEngine;
using System.Collections;

public class InstructionsOnClick : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
	}
	
	
	
	void OnMouseDown()  
	{
		Application.LoadLevel("InstructionsScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
