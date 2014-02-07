using UnityEngine;
using System.Collections;

public class EnemyBasic : MonoBehaviour {

	public float Speed;
	public float RotateSpeed;
	public float Acceleration;
	public float RotateAcceleration;

	// Use this for initialization
	void Start () {
		Speed = 0;
		RotateSpeed = 0;
		Acceleration = 0.2f;
		RotateAcceleration = 1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, Speed, 0, Space.Self);
		transform.Rotate(new Vector3(0,0,RotateSpeed));
	}
}
