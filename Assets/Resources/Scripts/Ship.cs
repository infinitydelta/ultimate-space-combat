using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public int hp;
	public int maxhp;
	public int score;
	public int energy;
	public int maxenergy;
	public float regenCD;
	float shieldduration;
	double hurr;
	//
	public GameObject missile;
	public GameObject laser;
	Vector3 mouse;
	public GameObject explosion;
	public GameObject missileClone;

	//
	public GUIText GUIenergy;
	public GUIText GUIHP;
	public GUIText GUIscore;


	// Use this for initialization
	void Start () {
		hurr = 0;
		maxhp = 100;
		hp = 100;

	}
	
	// Update is called once per frame
	void Update () {

		if (hp <= 0) {
			Application.LoadLevel ("GameOver");
				}

		mouse = Input.mousePosition;
		
		mouse = (Camera.main.ScreenToWorldPoint(mouse));
		mouse.z = 0;

//		if (Input.GetButtonDown("Fire1")) {
//
//			print (mouse);
//			shootLaser(mouse);
//
//		}

//		if (Input.GetButtonDown ("Fire2")) {
//
//			shootMissile(transform.position, mouse);
//		}

	}

	void OnGUI(){

		GUIHP.text = hp.ToString ();
		GUIscore.text = "score " + score.ToString ();

		//GUI.Box(new Rect(Screen.width*3/4,Screen.height/5/6,100,25), "Score: " + score.ToString());
		//GUI.Box(new Rect(Screen.width/8,Screen.height/5/6,100,25), "HP: " + hp.ToString());
	}

	void OnCollisionEnter2D ( Collision2D other) {
		if(other.collider.CompareTag("enemyMissile")||other.collider.CompareTag("enemyShip")){
			Instantiate (explosion,other.transform.position,Quaternion.identity);
		}
		Destroy (other.gameObject);
		hp -= 10;

	}

	void regenEnergy() {
		if (energy < maxenergy) {
			float energyTimer = 0;
			energyTimer += Time.deltaTime;
			if (energyTimer >= regenCD) {
				energy++;
				energyTimer = 0;
			}
		}
	
	}

	void shootLaser(Vector3 target) {

	
		//Instantiate (laser, transform.position, Quaternion.identity);

		//Instantiate (BlueLaser, target, transform.rotation);
	}

	void shootMissile(Vector3 start, Vector3 end) {
		Vector3 direction = end - start;

		missileClone = (GameObject)Instantiate (missile, transform.position, transform.rotation);
		missileClone.transform.Translate (direction* .5f);
	}

	void shieldUp() {
		//GameObject shieldClone = (GameObject)Instantiate ("efesf", transform.position, transform.rotation);
	}
	public void increaseScore(int increase){
		score += increase;
	}
}
