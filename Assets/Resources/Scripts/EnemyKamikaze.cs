using UnityEngine;
using System.Collections;

public class EnemyKamikaze : MonoBehaviour {
	GameObject Player;
	EnemyBasic BasicScript;
	Vector3 PlayerDirection;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		BasicScript = GetComponent<EnemyBasic> ();
		PlayerDirection = Player.transform.position - transform.position;
		transform.eulerAngles = new Vector3(0,0,Mathf.Atan2 (PlayerDirection.y, PlayerDirection.x) * Mathf.Rad2Deg - 90);
	}
	
	// Update is called once per frame
	void Update () {
		PlayerDirection = Player.transform.position - transform.position;
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
