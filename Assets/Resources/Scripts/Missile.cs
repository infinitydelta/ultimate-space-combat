using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	public GameObject explosion;
	float life;
	GameObject Player;
	Ship score;
	Orbits orbitScript;
	public AudioClip[] sounds;
	// Use this for initialization
	void Start () {
		audio.clip = sounds[Random.Range(0,2)];
		audio.Play ();
		Player = GameObject.Find ("MainShip");
		score = Player.GetComponent <Ship>();
		orbitScript = Player.GetComponent<Orbits>();

	}
	
	// Update is called once per frame
	void Update () {
		life += Time.deltaTime;
		if (life >= 10) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy (other.gameObject);
		score.increaseScore(10);
		if (other.gameObject.name=="SatelliteShip(Clone)") {
			orbitScript.OrbitLevels--;
		}
		explode();
			//other.gameObject.GetComponent<enemyShip>().hp--;
		}



	void explode() {
		print ("explode");
		GameObject circle = (GameObject)Instantiate (explosion,transform.position,Quaternion.identity);
		Destroy (this.gameObject);
	}
}
