using UnityEngine;
using System.Collections;

public class EnemyMissile : MonoBehaviour {
	GameObject Player;
	EnemyBasic BasicScript;
	Vector3 PlayerDirection;
	Vector3 orbitDestination;
	public int orbitDirection;
	float orbitOffset = 10f;
	float orbitInitialDistance = 25f;
	float orbitDistanceDecrease = 0.1f;
	float orbitDistance;

	// Use this for initialization
	void Start () {
		//orbitDirection = (int)Random.Range (0, 2) * 2 - 1;
		//orbitDirection = 1;
		Player = GameObject.FindGameObjectWithTag ("Player");
		BasicScript = GetComponent<EnemyBasic> (); 
		orbitDestination = transform.position - Player.transform.position;
		orbitDistance = orbitInitialDistance;
		orbitDestination = orbitDistance * orbitDestination.normalized + orbitDirection * orbitOffset * (new Vector3 (-orbitDestination.y, orbitDestination.x, 0).normalized);
		PlayerDirection = orbitDestination - transform.position;
		transform.eulerAngles = new Vector3(0,0,Mathf.Atan2 (PlayerDirection.y, PlayerDirection.x) * Mathf.Rad2Deg - 90);
	}
	
	// Update is called once per frame
	void Update () {
		orbitDestination = transform.position - Player.transform.position;
		orbitDistance -= orbitDistanceDecrease;
		orbitDestination = orbitDistance * orbitDestination.normalized + orbitDirection * orbitOffset * (new Vector3 (-orbitDestination.y, orbitDestination.x, 0).normalized);
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
