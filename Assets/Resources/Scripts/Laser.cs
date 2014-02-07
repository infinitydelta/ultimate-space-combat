using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	public AudioClip[] sounds;
	float life;
	GameObject Player;
	Ship score;
	Orbits orbitScript;
	public GameObject fire;
	public GameObject explosion;
	GameObject camera;
	// Use this for initialization
	void Start () {

		Player = GameObject.Find ("MainShip");
		score = Player.GetComponent <Ship>();
		orbitScript = Player.GetComponent<Orbits>();

		audio.clip = sounds[(int)Random.Range(0,2)];
		audio.Play ();
		//camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		life += Time.deltaTime;
		if (life >= 10) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) { 
		Destroy(this.gameObject);
		if(other.collider.CompareTag("enemyMissile")){
			Instantiate (explosion, other.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
		}
		if(other.collider.CompareTag("enemyShip")){
			//other.gameObject.audio.Play ();
			GameObject collided = other.gameObject;
			EnemyBasic script1 = collided.GetComponent<EnemyBasic>();
			script1.enabled = false;
			EnemyKamikaze script2 = collided.GetComponent<EnemyKamikaze>();
			if(script2!=null)
				script2.enabled = false;
			else{
				EnemyMissile script3 = collided.GetComponent<EnemyMissile>();
				if(script3!=null)
				script3.enabled = false;
				EnemyMissileShooter script4 = collided.GetComponent<EnemyMissileShooter>();
				if(script4!=null)
				script4.enabled = false;
			}
			if (other.gameObject.name=="SatelliteShip(Clone)") {
				orbitScript.OrbitLevels--;
			}
			Vector3 killVector = collided.transform.position - transform.position;
			ContactPoint2D contact = other.contacts[0];
			collided.rigidbody2D.velocity =killVector.normalized*10;
			GameObject flames = (GameObject) Instantiate(fire, contact.point,Quaternion.identity);
			flames.transform.LookAt(transform.position);
			flames.transform.parent = collided.transform;
			score.increaseScore(10);
		}
			//other.gameObject.GetComponent<enemyShip>().hp--;

		


	}
}
