using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	
	int maxSize=10;
	float time;
	ParticleSystem particle;
	Color color;
	Color particleColor;
	public AudioClip[] sounds;
	void Start () {
		audio.clip = sounds[Random.Range (0,3)];
		audio.Play();
		color = GetComponentInChildren<MeshRenderer>().renderer.material.color;
		particle = GetComponentInChildren <ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.lossyScale.x<maxSize){
			transform.localScale = new Vector3(transform.localScale.x+.1f,transform.localScale.y+.1f,0);

		time += Time.deltaTime;
	}
		else{
			if(color.a <0)
				Destroy(this.gameObject);
			transform.collider2D.isTrigger=true;
			particleColor.a -=.05f;
			color.a = color.a -.05f;
			this.GetComponentInChildren<MeshRenderer>().renderer.material.color = color;
		}


		
					
	}
	void OnCollisionEnter2D (Collision2D other) {
		Destroy (other.gameObject);
		//other.gameObject.GetComponent<enemyShip>().hp--;
	}
}
