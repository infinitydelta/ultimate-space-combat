using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour {

	// Use this for initialization
	float life=0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		life += Time.deltaTime;
		if (life >= 10) {
				Destroy (this.gameObject);
		}
	}
}
