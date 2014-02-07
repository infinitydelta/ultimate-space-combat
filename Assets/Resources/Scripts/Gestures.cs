using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Gestures: MonoBehaviour {
	List <Vector3> spots = new List<Vector3>();
	float farTop;
	float farRight;
	float farBottom;
	float farLeft;
	bool topChanged;
	bool rightChanged;
	bool leftChanged;
	bool bottomChanged;
	Vector3 start;
	int energy;
	float shieldCooldown;
	bool canShield;
	float missileCooldown;
	bool canMissile;
	public GameObject ship;
	public GameObject laser;
	public GameObject missile;
	public GameObject shield;
	public GameObject trail;

	public GUIText GUIenergy;
	public GUIText GUIHP;
	//public GUIText GUIscore;
	public GUIText GUIready;

	GameObject line;
	float time;
	float circleRadiusTolerance = 6.5f;

	// Use this for initialization
	void Start () {
		energy = 5;
		Ship shipScript = ship.GetComponent<Ship>();
		canShield = true;
		shieldCooldown = 0;
		missileCooldown = 0;
		canMissile = true;
	}

	void OnGUI(){
		if (canMissile) {
			GUIready.text = "missile ready";
			GUIready.color = Color.white;

		} else {
			GUIready.text = "missile loading";
			GUIready.color = Color.red;
		}
		GUIenergy.text = "energy " + energy.ToString ();
		//GUI.Box (new Rect (Screen.width / 4, Screen.height / 5 / 6, 100, 25), "Energy: " + energy.ToString ());
		}

	// Update is called once per frame
	void Update () {
		missileCooldown +=Time.deltaTime;
		shieldCooldown +=Time.deltaTime;
		time += Time.deltaTime;
		if(missileCooldown>3&&!canMissile){
			canMissile = true;
			missileCooldown = 0;
		}
		if(shieldCooldown>5&&!canShield){
			canShield = true;
			shieldCooldown = 0;
		}
		if(time>1){
			if(energy<5){
				energy++;
				time =0;
			}
		}
		if(Input.GetMouseButtonDown (0)){
			spots.Clear ();
		
			topChanged = false;
			bottomChanged = false;
			leftChanged = false;
			rightChanged = false;
			start = camera.ScreenToWorldPoint(Input.mousePosition);
			farTop = start.y;
			farBottom = start.y;
			farLeft = start.x;
			farRight = start.x;
			line = (GameObject)Instantiate (trail,new Vector3(start.x,start.y, 0),Quaternion.identity);
		}
		if(Input.GetMouseButton (0)){
			Vector3 spot = camera.ScreenToWorldPoint(Input.mousePosition);
			spots.Add(camera.ScreenToWorldPoint(Input.mousePosition));


			line.transform.position = new Vector3(spot.x,spot.y,0);

		}
		if(Input.GetMouseButtonUp (0)){
			Vector3 end = spots[spots.Count-1];
			/*for(int k=0;k<spots.Count-1;k++){
				Vector3 curSpot = spots[k];
				if(curSpot.x<farLeft){
					farLeft = curSpot.x;
					leftChanged = true;
=======
			if(time<.1){
				Vector2 curSpot = spots[spots.Count-1].normalized;

				shootLaser(curSpot*10);

			}
			else if(Vector3.Distance(start,end)>10){
				Vector2 curSpot = new Vector2(spots[spots.Count-1].x-spots[0].x,spots[spots.Count-1].y-spots[0].y).normalized;

				shootMissile(curSpot*10);

			}
			else{
				for(int k=0;k<spots.Count-1;k++){
					Vector3 curSpot = spots[k];
					if(curSpot.x<farLeft){
						farLeft = curSpot.x;
						leftChanged = true;
					}
					else if(curSpot.x>farRight){
						farRight = curSpot.x;
						rightChanged = true;
					}
					if(curSpot.y < farBottom){
						farBottom = curSpot.y;
						bottomChanged = true;
					}
					else if(curSpot.y>farTop){
						farTop = curSpot.y;
						topChanged = true;
					}
>>>>>>> .r28
				}
				else if(curSpot.x>farRight){
					farRight = curSpot.x;
					rightChanged = true;
				}
				if(curSpot.y < farBottom){
					farBottom = curSpot.y;
					bottomChanged = true;
				}
				else if(curSpot.y>farTop){
					farTop = curSpot.y;
					topChanged = true;
				}
			}
			spotsAverage /= spots.Count;
			int count = 0;
			if(leftChanged)
				count++;
			if(rightChanged)
				count++;
			if(bottomChanged)
				count++;
			if(topChanged)
				count++;
			if(count>3){
				GameObject field = (GameObject)Instantiate (shield,new Vector3(0,0,0),Quaternion.identity);
				
			}*/
			for(int k=0;k<spots.Count-1;k++){
				Vector3 curSpot = spots[k];
				if(curSpot.x<farLeft) farLeft = curSpot.x;
				if(curSpot.x>farRight) farRight = curSpot.x;
				if(curSpot.y < farBottom) farBottom = curSpot.y;
				if(curSpot.y>farTop) farTop = curSpot.y;
			}
			Vector3 spotsAverage = new Vector3 ((farRight+farLeft)/2, (farTop+farBottom)/2, 0);
			float averageDistance = 0;
			float nearestDistance = 200;
			float furthestDistance = 0;
			for(int k=0;k<spots.Count-1;k++){
				Vector3 VectorToCenter = spots[k] - spotsAverage;
				VectorToCenter.z = 0;
				averageDistance += VectorToCenter.magnitude;
				if (VectorToCenter.magnitude > furthestDistance) furthestDistance = VectorToCenter.magnitude;
				if (VectorToCenter.magnitude < nearestDistance) nearestDistance = VectorToCenter.magnitude;
			}
			averageDistance /= spots.Count;
			if(furthestDistance-nearestDistance < circleRadiusTolerance && nearestDistance >=1 && averageDistance >= 1){
				if(canShield){
					GameObject field = (GameObject)Instantiate (shield,new Vector3(0,0,0),Quaternion.identity);
					canShield = false;
				}
			}
			else if(Vector3.Distance(start,end)<7){
				if(energy>0){
				Vector2 curSpot = spots[spots.Count-1].normalized;
				GameObject projectile = (GameObject)Instantiate (laser, new Vector3(0,0,0),Quaternion.identity);
				projectile.rigidbody2D.velocity = curSpot.normalized*40;
				projectile.transform.LookAt(curSpot);
					energy--;
				}
			}
			else {
				if(canMissile){
				Vector2 curSpot = new Vector2(spots[spots.Count-1].x-spots[0].x,spots[spots.Count-1].y-spots[0].y).normalized;
				GameObject projectile = (GameObject)Instantiate (missile ,new Vector3(0,0,0), Quaternion.identity);
				projectile.rigidbody2D.velocity = curSpot.normalized*20;
				projectile.transform.LookAt(curSpot);
					canMissile = false;
				}
			}
		}
	}


	void shootLaser(Vector2 target) {
		GameObject projectile = (GameObject)Instantiate (laser, new Vector3(0,0,0),Quaternion.identity);
		projectile.rigidbody2D.velocity = target*7;
		projectile.transform.LookAt(target);
	}

	void shootMissile(Vector2 target) {
		GameObject projectile = (GameObject)Instantiate (missile ,new Vector3(0,0,0), Quaternion.identity);
		projectile.rigidbody2D.velocity = target*7;
		projectile.transform.LookAt(target);
	}
	
}
