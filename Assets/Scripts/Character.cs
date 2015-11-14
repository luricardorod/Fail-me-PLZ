using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	 public float velocidad = 10f;
	 public float jump = 10f;
	 public bool flagMoveUp = false;
	 public bool flagMoveDown = false;
	 public bool flagJump = false;
	 private float positionActual = 0f;
	 private float positionFutura = 0f;
	 Camera cam;

	 void Start () {
	   cam = Camera.main;
	 }

	// Update is called once per frame
	void Update () {
		if (flagMoveUp) {
			if (transform.position.y > positionFutura) {
				positionActual = transform.position.y;
				flagMoveUp = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
				cam.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
			}
		}

		if (flagMoveDown) {
			if (transform.position.y < positionFutura) {
				positionActual = transform.position.y;
				flagMoveDown = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
				cam.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
			}
		}

		if (flagJump) {

			if (transform.position.y > positionActual + 2) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -jump);
			}
			if (transform.position.y < positionActual) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
				flagJump = false;
			}
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !flagJump) {
			flagJump = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, jump);
    }
	}

	void OnTriggerEnter2D(Collider2D colider) {
		if (colider.name == "objectUp" && !flagMoveUp) {
			flagMoveUp = true;
		  positionFutura = positionActual + 6f;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, velocidad);
			cam.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, velocidad);
		}
		if (colider.name == "objectDown" && !flagMoveDown) {
			flagMoveDown = true;
		  positionFutura = positionActual - 6f;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -velocidad);
			cam.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -velocidad);
		}
  }
}
