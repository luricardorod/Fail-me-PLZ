using UnityEngine;
using System.Collections;

public class FloorSpawner : MonoBehaviour {
	public GameObject pisoA, pisoB;
	private Vector2 spawnPoint;
	public float timerSpawner, velocidadSpawn;

	// Use this for initialization
	void Start () {
	}

	void Update (){
		timerSpawner += Time.deltaTime;
		if (timerSpawner >= velocidadSpawn) {
			timerSpawner = 0;
			launchFloor();
		}
	}

	// Update is called once per frame
	void launchFloor () {
		int i = 0;
		while (i < 4) {
			int selectObstacule = Random.Range(0,2);
			if (selectObstacule == 1) {
				spawnPoint = new Vector2(transform.position.x - i , transform.position.y);
				Instantiate(pisoA, spawnPoint, Quaternion.identity);
				spawnPoint = new Vector2(transform.position.x - i , transform.position.y + 9);
				Instantiate(pisoA, spawnPoint, Quaternion.identity);
				spawnPoint = new Vector2(transform.position.x - i , transform.position.y -9);
				Instantiate(pisoA, spawnPoint, Quaternion.identity);
			} else {
				spawnPoint = new Vector2(transform.position.x - i , transform.position.y);
				Instantiate(pisoB, spawnPoint, Quaternion.identity);
				spawnPoint = new Vector2(transform.position.x - i , transform.position.y + 9);
				Instantiate(pisoB, spawnPoint, Quaternion.identity);
				spawnPoint = new Vector2(transform.position.x - i , transform.position.y -9);
				Instantiate(pisoB, spawnPoint, Quaternion.identity);
			}
			i++;
		}
	}
}
