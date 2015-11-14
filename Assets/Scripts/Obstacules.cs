using UnityEngine;
using System.Collections;

public class Obstacules : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-1, 0);
	}

	// Update is called once per frame
	void Update () {

	}
}
