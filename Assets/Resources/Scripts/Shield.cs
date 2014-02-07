using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	float duration = 3;
	float life;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		life += Time.deltaTime;
		if (life >= duration) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("enemyLaser")) {
			Destroy (other.gameObject);

		}

		if (other.gameObject.CompareTag ("enemyMissile")) {
			Destroy (other.gameObject);
			
		}


	}
}
