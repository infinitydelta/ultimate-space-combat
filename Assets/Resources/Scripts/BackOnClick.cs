using UnityEngine;
using System.Collections;

public class BackOnClick : MonoBehaviour 
{
	public AudioClip select;
	// Use this for initialization
	void Start () {

	}
	
	void OnMouseDown()  
	{
		//audio.PlayOneShot(audio);
		Application.LoadLevel("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
