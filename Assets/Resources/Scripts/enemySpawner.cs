using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {
	double time;
	float spawnCoolDown;
	GameObject[] enemies;

	public GameObject enemy1;
	public GameObject enemy2;

	public double enemySpawnRate = 2; //seconds between spawn
	int enemyMax = 10;

	float enemySpawnRateDeviation;
	// Use this for initialization
	void Start () {
		enemySpawnRateDeviation = (float) enemySpawnRate;

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		spawnCoolDown += Time.deltaTime;

		enemies = GameObject.FindGameObjectsWithTag ("enemyShip");

		if (enemies.Length < enemyMax) {
			if (spawnCoolDown >= enemySpawnRateDeviation) {
				spawnEnemy();
				spawnCoolDown = 0;
				enemySpawnRateDeviation = (float) enemySpawnRate * Random.Range(.5f,1.5f);

			}
		}

		increaseDifficulty ();

	}

	void increaseDifficulty() {
		if (enemyMax < 30) {
			enemyMax += (int)time / 10;
		}
		if (enemySpawnRate > .3f) {
			enemySpawnRate -= (double)time / 80000;
		}
	}

	void spawnEnemy() {
		if (Random.Range(0,2) == 1) {
		Instantiate (enemy1, randomEnemySpawn() , Quaternion.identity);
		}
		else {
			Instantiate (enemy2, randomEnemySpawn() , Quaternion.identity);
		}
	}

	Vector3 randomEnemySpawn() {
		Vector3 spawnPoint = new Vector3(0,0,0);
		if (Random.Range (0, 2) == 1) {

				spawnPoint.x = Random.Range (-35, 35);

				if (Random.Range (0, 2)== 1) {
						spawnPoint.y = 20;
				} else {
						spawnPoint.y = -20;
				}

		} else {
				spawnPoint.y = Random.Range (-20, 20);

				if (Random.Range (0, 2) == 1) {
						spawnPoint.x = 35;
				} else {
						spawnPoint.x = -35;
				}

		}
		return spawnPoint;
	}
}
