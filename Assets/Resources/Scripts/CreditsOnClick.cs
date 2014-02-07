using UnityEngine;
using System.Collections;

public class CreditsOnClick : MonoBehaviour 
{
	//public AudioClip select;
	// Use this for initialization
	void Start () {

	}
		
	void OnMouseDown()  
	{
		//audio.PlayOneShot (select);
		//DontDestroyOnLoad(this.gameObject);
		Application.LoadLevel("CreditsScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
