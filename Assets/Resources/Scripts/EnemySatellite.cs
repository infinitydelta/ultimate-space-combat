using UnityEngine;
using System.Collections;

public class EnemySatellite : MonoBehaviour {
	GameObject Player;
	EnemyBasic BasicScript;
	Orbits PlayerScript;
	Vector3 PlayerDirection;
	Vector3 orbitDestination;
	int lastPlayerOrbitLevel = 0;
	int orbitLevel = 0;
	public int orbitDirection;
	float orbitOblongness = 1.75f;
	float orbitOffset = 10f;
	float orbitInitialDistance = 8f;
	float orbitAdditionalDistance = 5f;
	
	// Use this for initialization
	void Start () {
		orbitDirection = (int)Random.Range (0, 2) * 2 - 1;
		Player = GameObject.FindGameObjectWithTag ("Player");
		BasicScript = GetComponent<EnemyBasic> (); 
		PlayerScript = Player.GetComponent<Orbits> ();
		orbitDestination = transform.position - Player.transform.position;
		orbitLevel = PlayerScript.OrbitLevels;
		PlayerScript.OrbitLevels++;
		orbitDestination = (orbitLevel * orbitAdditionalDistance + orbitInitialDistance) * orbitDestination.normalized + orbitDirection * orbitOffset * (new Vector3 (-orbitDestination.y, orbitDestination.x, 0).normalized);
		orbitDestination.x *= orbitOblongness;
		PlayerDirection = orbitDestination - transform.position;
		transform.eulerAngles = new Vector3(0,0,Mathf.Atan2 (PlayerDirection.y, PlayerDirection.x) * Mathf.Rad2Deg - 90);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerScript.OrbitLevels < lastPlayerOrbitLevel) {
			orbitLevel--;
		}
		lastPlayerOrbitLevel = PlayerScript.OrbitLevels;
		orbitDestination = transform.position - Player.transform.position;
		orbitDestination = (orbitLevel * orbitAdditionalDistance + orbitInitialDistance) * orbitDestination.normalized + orbitDirection * orbitOffset * (new Vector3 (-orbitDestination.y, orbitDestination.x, 0).normalized);
		orbitDestination.x *= orbitOblongness;
		PlayerDirection = orbitDestination - transform.position;
		transform.eulerAngles = new Vector3(0,0,Mathf.Atan2 (PlayerDirection.y, PlayerDirection.x) * Mathf.Rad2Deg - 90);
		BasicScript.Speed = BasicScript.Acceleration;
	}
	void OnCollisionEnter(Collision other)
	{
		//if(other.gameObject.tag=="Player")
		Destroy(this.gameObject);
		print ("Collided");
	}
}
