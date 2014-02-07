using UnityEngine;
using System.Collections;

public class GameOverTransition : MonoBehaviour {
	public float time= 5;
	// Use this for initialization
	void Start () {

	}

	void OnMouseDown()  
	{
		Application.LoadLevel("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine( Count() );

	}

	IEnumerator Count () {
		yield return new WaitForSeconds(time);
		Application.LoadLevel("MainMenu");
		}
}
