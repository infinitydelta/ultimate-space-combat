using UnityEngine;
using System.Collections;

public class enemyLaserShoot : MonoBehaviour {
	public GameObject enemylaser;
	public float cooldown = 1f;
	float timer= 0;

	GameObject playerShip;
	// Use this for initialization
	void Start () {
		playerShip = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= cooldown) {
			shoot (new Vector3(playerShip.transform.position.x, playerShip.transform.position.y, 0));
			timer = 0;
		}

	}

	void shoot(Vector3 target) {
		GameObject projectile = (GameObject)Instantiate (enemylaser, transform.position,Quaternion.identity);
		projectile.rigidbody2D.velocity = (target- transform.position).normalized *4.5f;
		projectile.transform.LookAt(new Vector2(target.x, target.y));
	}
}
