using UnityEngine;
using System.Collections;

public class EnemyMissileShooter : MonoBehaviour {
	public GameObject EnemyMissile;
	EnemySatellite SatelliteScript;
	int Timer;
	int MinTime;
	int MaxTime;
	// Use this for initialization
	void Start () {
		MinTime = 300;
		MaxTime = 450;
		Timer = Random.Range (MinTime, MaxTime);
		SatelliteScript = GetComponent<EnemySatellite> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer <= 0) {
			GameObject Missile = (GameObject)Instantiate (EnemyMissile, transform.position, transform.rotation);
			EnemyMissile MissileScript = Missile.GetComponent<EnemyMissile>();
			MissileScript.orbitDirection = SatelliteScript.orbitDirection;
			Timer = Random.Range (MinTime, MaxTime);
		}
		Timer--;
	}
}
