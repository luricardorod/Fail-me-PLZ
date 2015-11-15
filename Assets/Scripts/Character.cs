using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	 public float velocidad = 10f;
	 public float jump = 5f;
	 public bool flagMoveUp = false;
	 public bool flagMoveDown = false;
	 public bool flagJump = false;
	 private float positionActual = 0f;
	 private float positionFutura = 0f;
	 private float Timer = 0.0f;
	 public float TimerMin = 3.0f;
	 public float timerNextSpawn = 3.0f;
	 public float dificulty = 2.0f;
	 public float jumpHigh = 2.5f;
	 public GameObject obstaculeDown;
   public GameObject obstaculeUp;
   public GameObject obstaculeDeath;
	 public GameObject obstaculeDownFloorUp;
   public GameObject obstaculeUpFloorUp;
   public GameObject obstaculeDeathFloorUp;
	 public GameObject obstaculeDownFloorDown;
   public GameObject obstaculeDeathFloorDown;
   public GameObject obstaculeUpFloorDown;
   public GameObject hardcoreButton;
	 private Vector2 spawnPoint;
	 public GameObject[] livingItems;

	 void Start () {
	 }
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (Timer > timerNextSpawn && !hardcoreButton.activeSelf) {
			Timer = 0.0f;
			SpawnObstacules();
		}
		if (flagMoveUp) {
			if (transform.position.y > positionFutura) {
				transform.position = new Vector3(transform.position.x,positionFutura,0);
				positionActual = transform.position.y;
				flagMoveUp = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
				//transform.position.y = positionFutura;
			}
		}

		if (flagMoveDown) {
			if (transform.position.y < positionFutura) {
				transform.position = new Vector3(transform.position.x,positionFutura,0);
				positionActual = transform.position.y;
				flagMoveDown = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
				//transform.position = Vector3 (transform.position.x, positionFutura, transform.position.z);
			}
		}

		if (flagJump) {
			if (transform.position.y > positionActual + jumpHigh) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -jump);
			}
			if (transform.position.y < positionActual && flagJump) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
				transform.position = new Vector3(transform.position.x,positionActual,0);
				flagJump = false;
			}
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && !flagJump && !flagMoveDown &&  !flagMoveUp && !hardcoreButton.activeSelf) {
			flagJump = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, jump);
    }
		if (Input.GetKeyDown("space") && !flagJump && !flagMoveDown &&  !flagMoveUp && !hardcoreButton.activeSelf) {
			flagJump = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, jump);
		}
	}

	void OnTriggerEnter2D(Collider2D colider) {
		if ((colider.name == "hidrante(Clone)" || colider.name == "trampolin(Clone)" || colider.name == "sillon(Clone)")  && !flagMoveUp ) {
			if (positionActual < 9) {
				flagJump = false;
				Destroy (colider.gameObject);
				flagMoveUp = true;
			  positionFutura = positionActual + 9f;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, +velocidad);
			} else {
				muerte();
			}
		} else if ((colider.name == "banana(Clone)" || colider.name == "boteBasura(Clone)") && !flagMoveDown) {
			if (positionActual > -9) {
				flagJump = false;
				Destroy (colider.gameObject);
				flagMoveDown = true;
			  positionFutura = positionActual - 9f;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -velocidad);
			} else {
				muerte();
			}
		} else {
			muerte();
		}
  }

	void SpawnObstacules () {
		timerNextSpawn = Random.Range(0.4f, 2.2f);
		Debug.Log(timerNextSpawn);
		int selectObstacule = Random.Range(0,3);
		if (selectObstacule == 2) {
			spawnPoint = new Vector2(transform.position.x + 16, 0);
			Instantiate(obstaculeUp, spawnPoint, Quaternion.identity);
			spawnPoint = new Vector2(transform.position.x + 16, 9);
			Instantiate(obstaculeUpFloorUp, spawnPoint, Quaternion.identity);
			spawnPoint = new Vector2(transform.position.x + 16, -9);
			Instantiate(obstaculeUpFloorDown, spawnPoint, Quaternion.identity);
		} else if(selectObstacule == 1) {
			spawnPoint = new Vector2(transform.position.x + 16, 0);
			Instantiate(obstaculeDown, spawnPoint, Quaternion.identity);
			spawnPoint = new Vector2(transform.position.x + 16, 9);
			Instantiate(obstaculeDownFloorUp, spawnPoint, Quaternion.identity);
			spawnPoint = new Vector2(transform.position.x + 16, -9);
			Instantiate(obstaculeDownFloorDown, spawnPoint, Quaternion.identity);
		} else {
			spawnPoint = new Vector2(transform.position.x + 16, 0);
			Instantiate(obstaculeDeath, spawnPoint, Quaternion.identity);
			spawnPoint = new Vector2(transform.position.x + 16, 9);
			Instantiate(obstaculeDeathFloorUp, spawnPoint, Quaternion.identity);
			spawnPoint = new Vector2(transform.position.x + 16, -9);
			Instantiate(obstaculeDeathFloorDown, spawnPoint, Quaternion.identity);
		}
	}

	void muerte()  {
        // suspend execution for 5 seconds
				gameObject.SetActive(false);
        livingItems = GameObject.FindGameObjectsWithTag("items");
				Debug.Log(livingItems);
        foreach (GameObject item in livingItems) {
					Destroy(item);
        }
				hardcoreButton.SetActive(true);
				Debug.Log(hardcoreButton.GetComponent<HardcoreBotton>().isTheBottomOnScreen);
				hardcoreButton.GetComponent<HardcoreBotton>().isTheBottomOnScreen = true;
				hardcoreButton.transform.position = new Vector3(0,positionActual,hardcoreButton.transform.position.z);
  }
}
